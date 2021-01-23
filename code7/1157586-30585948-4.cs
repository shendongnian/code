    public class SimpleCompressedPrefixTrie
    {
        private readonly Node _root = new Node();
        private class Node
        {
            private Dictionary<char, Node> _children;
            public string PrefixValue = string.Empty;
            public bool IsTerminal;
            public Node Add(string word, ref int startIndex)
            {
                var n = FindSharedPrefix(word, startIndex);
                startIndex += n;
                if (n == PrefixValue.Length) // full prefix match
                {
                    if (startIndex == word.Length) // full match
                        IsTerminal = true;
                    else
                        return AddToChild(word, ref startIndex);
                }
                else // partial match, need to split this node's prefix.
                    SplittingAdd(word, n, ref startIndex);
                return null;
            }
            public Node Find(string word, ref int startIndex, out int matchLen)
            {
                var n = FindSharedPrefix(word, startIndex);
                startIndex += n;
                matchLen = -1;
                if (n == PrefixValue.Length)
                {
                    if (IsTerminal)
                        matchLen = startIndex;
                    var child = default(Node);
                    if (_children != null && startIndex < word.Length && _children.TryGetValue(word[startIndex], out child))
                    {
                        startIndex++; // consumed map key character.
                        return child;
                    }
                }
                return null;
            }
            private Node AddToChild(string word, ref int startIndex)
            {
                var key = word[startIndex++]; // consume the mapping character
                var nextNode = default(Node);
                if (_children == null)
                    _children = new Dictionary<char, Node>();
                else if (_children.TryGetValue(key, out nextNode))
                    return nextNode;
                var remainder = word.Substring(startIndex);
                _children[key] = new Node() { PrefixValue = remainder, IsTerminal = true };
                return null; // consumed.
            }
            private void SplittingAdd(string word, int n, ref int startIndex)
            {
                var curChildren = _children;
                _children = new Dictionary<char, Node>();
                _children[PrefixValue[n]] = new Node()
                {
                    PrefixValue = this.PrefixValue.Substring(n + 1),
                    IsTerminal = this.IsTerminal,
                    _children = curChildren
                };
                PrefixValue = PrefixValue.Substring(0, n);
                IsTerminal = startIndex == word.Length;
                if (!IsTerminal)
                {
                    var prefix = word.Length > startIndex + 1 ? word.Substring(startIndex + 1) : string.Empty;
                    _children[word[startIndex]] = new Node() { PrefixValue = prefix, IsTerminal = true };
                    startIndex++;
                }
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
            var startNdx = 0;
            var cur = _root;
            while (cur != null)
            {
                var matchLen = 0;
                cur = cur.Find(searchWord, ref startNdx, out matchLen);
                if (matchLen > 0)
                    yield return searchWord.Substring(0, matchLen);
            };
        }
    }
