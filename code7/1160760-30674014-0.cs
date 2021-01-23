        public bool IsStringInvalid(string text)
        {
            return string.IsNullOrEmpty(text) ||
                text.Length <= 4 ||
                !Regex.IsMatch(text, textCodeFormat);
        }
