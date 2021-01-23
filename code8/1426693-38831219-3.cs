    public static class StringExtensions
    {
        public static FirstFourAreNumeric(this string input)
        {
            int number;
            if(string.IsNullOrEmpty(input) || input.Length < 4)
            {
                throw new Exception("Not 4 chars long");
            }
            return int.TryParse(input.Substring(4), out number);
        }
    }
