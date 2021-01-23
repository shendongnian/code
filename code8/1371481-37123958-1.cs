    public class ModifiableClass
    {
        private readonly int _origValue;
        public int Value;
        public ModifiableClass(int initialValue)
        {
            _origValue = Value = initialValue;
        }
        public bool IsModified()
        {
            return Value != _origValue;
        }
    }
