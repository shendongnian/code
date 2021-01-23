    void ShowSubText()
        {
            String inputString = "NormalText";
            var nonDigitSymbolsTable = new Dictionary<char, char>();
            nonDigitSymbolsTable.Add('+', 'A');
            nonDigitSymbolsTable.Add('-', 'B');
            nonDigitSymbolsTable.Add('=', 'C');
            nonDigitSymbolsTable.Add('(', 'D');
            nonDigitSymbolsTable.Add(')', 'E');
            StringBuilder temp = new StringBuilder();
            int checkToDigit = 0;
            foreach (char t in "1234567890+-=()".ToCharArray())
            {
                if (int.TryParse(t.ToString(), out checkToDigit))
                    temp.Append("\\u208" + t);
                else
                    temp.Append("\\u208" + nonDigitSymbolsTable[t]);
            }
            MessageBox.Show(inputString + GetStringFromUnicodeSymbols(temp.ToString()));
        }
        string GetStringFromUnicodeSymbols(string unicodeString)
        {
            var stringBuilder = new StringBuilder();
            foreach (Match match in Regex.Matches(unicodeString, @"\\u(?<Value>[a-zA-Z0-9]{4})"))
            {
                stringBuilder.AppendFormat(@"{0}",
                                           (Char)int.Parse(match.Groups["Value"].Value,System.Globalization.NumberStyles.HexNumber));
            }
            return stringBuilder.ToString();
        }
    
