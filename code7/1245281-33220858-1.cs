        public static decimal? ConvertAsDecimalNullable(this string input, decimal? defaultValue = null)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                decimal result;
                if (decimal.TryParse(input, out result))
                {
                    return result;
                }
            }
            return defaultValue;
        }
