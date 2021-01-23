        private static string GetCommonPrefix(params string[] values)
        {
            string result = string.Empty;
            int? resultLength = null;
            if (values != null)
            {
                if (values.Length > 1)
                {
                    var min = values.Min(value => value.Length);
                    for (int charIndex = 0; charIndex < min; charIndex++)
                    {
                        for (int valueIndex = 1; valueIndex < values.Length; valueIndex++)
                        {
                            if (values[0][charIndex] != values[valueIndex][charIndex])
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
                }
                else if (values.Length > 0)
                {
                    result = values[0];
                }
            }
            return result;
        }
