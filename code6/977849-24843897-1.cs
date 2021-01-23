    /// <summary>
            /// This is used to properly trail leading zeros with usage of NumberFormatInfo culture class later in string
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
    private static string ManipulateCurrencyString(string input)
            {
                char lastCharacter = input.Substring(input.Length - 1, 1)[0];
    
                if (Char.IsNumber(lastCharacter))
                {
                // for currencies with symbol in front
                input = input.TrimEnd("0".ToCharArray()).TrimEnd(".".ToCharArray());
                }
                else
                {
                // for currencies with symbol in the end
                string symbol = input.Substring(input.Length - 1, 1);
                string number = input.Substring(0, input.Length - 2).TrimEnd("0".ToCharArray()).TrimEnd(".".ToCharArray()).TrimEnd(",".ToCharArray());
    
                input = number + " " + symbol;
                }
    
                return input;
            }
