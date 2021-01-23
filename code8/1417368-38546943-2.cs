    public static class StringTrimExtensions
    {
        public static int CharactersTrimmed { get; private set; }
        private static readonly object CharactersTrimmedLock = new object();
        public static string Trim(this string input)
        {
            var trimmed = input.Trim();
            lock (CharactersTrimmedLock)
            {
                CharactersTrimmed += (input.Length - trimmed.Length);
            }
            return trimmed;
        }
    }
