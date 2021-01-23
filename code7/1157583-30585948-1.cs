    public class SimpleCompressedPrefixTrie
    {
        private readonly Node _root = new Node();
        private class Node
        {
            public string PrefixValue = string.Empty;
            public bool IsTerminal;
            // Note: a more compact alternative representation would be to use
            // a dynamic array/list with inserts in sorted order using a binary 
            // search on the first character of a node prefix value.
            private Dictionary<char, Node> _children;
            public Node Add(string word, ref int startIndex)
            {
                var nextNode = default(Node);
                var n = FindSharedPrefix(word, startIndex);
                startIndex += n;
                if (n == PrefixValue.Length) // full prefix match
                {
                    if (startIndex == word.Length) // full word match
                        IsTerminal = true;
                    else if (_children == null || !_children.TryGetValue(word[startIndex], out nextNode))
                    {
                        if (_children == null)
                            _children = new Dictionary<char, Node>();
                        var remainder = word.Substring(startIndex);
                        _children[remainder[0]] = new Node() { PrefixValue = remainder, IsTerminal = true };
                    }
                } 
                else // partial match, need to split this node's prefix.
                {
                    var curChildren = _children;
                    _children = new Dictionary<char, Node>();
                    _children[PrefixValue[n]] = new Node() { PrefixValue = this.PrefixValue.Substring(n), IsTerminal = this.IsTerminal, _children = curChildren };
                    PrefixValue = PrefixValue.Substring(0, n);
                    IsTerminal = startIndex == word.Length;
                    if (!IsTerminal)
                        _children[word[startIndex]] = new Node() { PrefixValue = word.Substring(startIndex), IsTerminal = true };
                    nextNode = null; // consumed.
                }
                return nextNode; 
            }
            public Node Find(string word, ref int startIndex, out bool matches)
            {
                var child = default(Node);
                var n = FindSharedPrefix(word, startIndex);
                startIndex += n;
                matches = n == PrefixValue.Length;
                if (matches && _children != null && _children.TryGetValue(word[startIndex], out child))
                    return child;
                return null;
            }
            private int FindSharedPrefix(string word, int startIndex)
            {
                var n = Math.Min(PrefixValue.Length, word.Length - startIndex);
                var len = 0;
                while (len < n && PrefixValue[len] == word[len + startIndex])
                    len++;
                return len;
            }
        }
        public void AddWord(string word)
        {
            var ndx = 0;
            var cur = _root;
            while (cur != null)
                cur = cur.Add(word, ref ndx);
        }
        public IEnumerable<string> FindWordsMatchingPrefixesOf(string searchWord)
        {
            var ndx = 0;
            var cur = _root;
            var matches = false;
            while (cur != null)
            {
                var isTerminal = cur.IsTerminal;
                cur = cur.Find(searchWord, ref ndx, out matches);
                if (isTerminal && matches)
                    yield return searchWord.Substring(0, ndx);
            };
        }
    }
