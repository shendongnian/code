    public static class StringTrimExtensions
    {
        private static int _charactersTrimmed;
        public static int CharactersTrimmed { get {return _charactersTrimmed;}  }
        public static string Trim(this string input)
        {
            var trimmed = input.Trim();
            var countOfTrimmedCharacters = input.Length - trimmed.Length;
            Interlocked.Add(ref _charactersTrimmed, countOfTrimmedCharacters);
            return trimmed;
        }
    }
