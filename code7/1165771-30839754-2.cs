                private static string EncodeCasingIndifference(string originalText, char markerChar)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in originalText)
            {
                if (char.IsUpper(c))
                    sb.Append(markerChar);
                sb.Append(c);
            }
            return sb.ToString();
        }
        private static string DecodeCasingIndifference(string encryptedText, char markerChar)
        {
            StringBuilder sb = new StringBuilder();
            bool nextCharIsUpper = false;
            foreach(char c in encryptedText)
            {
                if(c == markerChar)
                {
                    nextCharIsUpper = true;
                    continue;
                }
                if(nextCharIsUpper)
                    sb.Append(char.ToUpperInvariant(c));
                else
                    sb.Append(char.ToLowerInvariant(c));
                nextCharIsUpper = c == markerChar;
            }
            return sb.ToString();
        }
