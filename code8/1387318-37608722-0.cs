        private string NextChar(string character)
        {
            if (character == null) throw new ArgumentNullException(nameof(character));
            if (character.Length != 1) throw new ArgumentOutOfRangeException(nameof(character), "You can use only a single letter string");
            return Convert.ToString(NextChar(character[0]));
        }
        private char NextChar(char character)
        {
            return (char)(character + 1);
        }
