    public class SimplePrefixTrie
    {
        private readonly Node _root = new Node(); // root represents empty string.
        private class Node
        {
            public Dictionary<char, Node> Children;
            public bool IsTerminal; // whether a full word ends here.
            public Node Find(string word, int index)
            {
                var child = default(Node);
                if (index < word.Length && Children != null)
                    Children.TryGetValue(word[index], out child);
                return child;
            }
            public Node Add(string word, int toConsume)
            {
                var child = default(Node);
                if (toConsume == word.Length)
                    this.IsTerminal = true;
                else if (Children == null || !Children.TryGetValue(word[toConsume], out child))
                {
                    if (Children == null)
                        Children = new Dictionary<char, Node>();
                    Children[word[toConsume]] = child = new Node();
                }
                return child;
            }
        }
        public void AddWord(string word)
        {
            var ndx = 0;
            var cur = _root;
            while (cur != null)
                cur = cur.Add(word, ndx++);
        }
        public IEnumerable<string> FindWordsMatchingPrefixesOf(string searchWord)
        {
            var ndx = 0;
            var cur = _root;
            while (cur != null)
            {
                if (cur.IsTerminal)
                    yield return searchWord.Substring(0, ndx);
                cur = cur.Find(searchWord, ndx++);
            }
        }
    }
