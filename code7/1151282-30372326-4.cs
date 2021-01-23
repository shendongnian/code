    public class CharSwap
    {
        private string alphabet;
        private Dictionary<char, int> indexLookup;
        public CharSwap() : this("abcdefghijklmnopqrstuvwxyz") { }
        public CharSwap(string alphabet)
        {
            this.alphabet = alphabet;
            indexLookup = alphabet.Select((chr, index) => new { chr, index }).ToDictionary(x => x.chr, x => x.index);
        }
        public char? OppositeChar(char input)
        {
            char lowerChar = Char.ToLowerInvariant(input);
            if (!indexLookup.ContainsKey(lowerChar))
                return null;
            int indexOfChar = indexLookup[lowerChar];
            return Char.IsUpper(input) 
                ? Char.ToUpperInvariant(alphabet[25 - indexOfChar])
                : alphabet[25 - indexOfChar];
        }
    }
