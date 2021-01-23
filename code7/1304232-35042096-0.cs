    private static string RemoveThousandSeparator(string input)
        {
            Regex removeThousandSeparatorExpr = new Regex(@"^-?(?:\d+|\d{1,3}(?:\"
                            + <CultureInfo>.NumberGroupSeparator + @"\d{3})+)(?:\"
                            + <CultureInfo>.NumberDecimalSeparator + @"\d+)?$");
            Match match = removeThousandSeparatorExpr.Match(input);
            if (match.Success)
            {
                input = input.Replace(<CultureInfo>.NumberGroupSeparator, "");
            }
            else
            {
                throw new Exception("Invalid input value");
            }
            return input;
        }
