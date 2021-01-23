        public int Compare(string s1, string s2)
        {
            double number1, number2;
            var isS1Numeric = double.TryParse(s1, out number1);
            var isS2Numeric = double.TryParse(s2, out number2);
            if (isS1Numeric && isS2Numeric)
            {
                if (number1 > number2) return 1;
                if (number1 < number2) return -1;
                return 0;
            }
            if (isS1Numeric)
                return 1;
            if (isS2Numeric)
                return -1;
            bool s1StartsWithLetter = char.IsLetter(s1.FirstOrDefault());
            bool s2StartsWithLetter = char.IsLetter(s2.FirstOrDefault());
            if (s1StartsWithLetter == s2StartsWithLetter)
                return String.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);
            return s1StartsWithLetter ? -1 : 1;
        }
