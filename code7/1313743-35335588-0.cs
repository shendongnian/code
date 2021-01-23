    public static string FormatCaseConvention(string text)
            {
                var formatted = String.Empty;
                foreach (char letter in text)
                {
                    if (Char.IsUpper(letter) && formatted.Length > 0)
                    {
                      if (char.IsUpper(letter) && formatted.Length > 0 && char.IsLower([i + 1]))
                          formatted += " " + letter;
                    }
                    else
                    {
                        formatted += letter;
                    }
                }
        
                return formatted;
            }
