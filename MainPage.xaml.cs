using System;
using Microsoft.Maui.Controls;

namespace RomanNumberConverter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnConvertButtonClicked(object sender, EventArgs e)
        {
            if (int.TryParse(NumberEntry.Text, out int number) && number > 0 && number <= 3999)
            {
                ResultLabel.Text = $"Římská číslice: {ToRoman(number)}";
            }
            else
            {
                ResultLabel.Text = "Zadejte platné číslo (1 - 3999).";
            }
        }

        private string ToRoman(int number)
        {
            var romanNumerals = new[]
            {
                new { Value = 1000, Numeral = "M" },
                new { Value = 900, Numeral = "CM" },
                new { Value = 500, Numeral = "D" },
                new { Value = 400, Numeral = "CD" },
                new { Value = 100, Numeral = "C" },
                new { Value = 90, Numeral = "XC" },
                new { Value = 50, Numeral = "L" },
                new { Value = 40, Numeral = "XL" },
                new { Value = 10, Numeral = "X" },
                new { Value = 9, Numeral = "IX" },
                new { Value = 5, Numeral = "V" },
                new { Value = 4, Numeral = "IV" },
                new { Value = 1, Numeral = "I" },
            };

            string result = string.Empty;
            foreach (var item in romanNumerals)
            {
                while (number >= item.Value)
                {
                    result += item.Numeral;
                    number -= item.Value;
                }
            }

            return result;
        }
    }
}
