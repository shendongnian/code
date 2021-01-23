        private static string GetCommonPrefix(params string[] values)
        {
            string result = string.Empty;
            int? resultLength = null;
            var min = values.Min(value => value.Length);
            for (int charIndex = 0; charIndex < min; charIndex++)
            {
                for (int valueIndex = 1; valueIndex < values.Length; valueIndex++)
                {
                    if (values[0] != values[valueIndex])
                    {
                        resultLength = charIndex;
                        break;
                    }
                }
                if (resultLength.HasValue)
                {
                    break;
                }
            }
            if (resultLength.HasValue &&
                resultLength.Value > 0)
            {
                result = values[0].Substring(0, resultLength.Value);
            }
            return result;
        }
