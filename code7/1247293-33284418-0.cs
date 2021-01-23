    class myClass : IEnumerable<KeyValuePair<int, string>>
    {
        public Dictionary<int, string> dctIdName = new Dictionary<int, string>();
        public myClass()
        {
            for (int idx = 0; idx < 100; idx++)
            {
                dctIdName.Add(idx, string.Format("Item{0}", idx));
            }
        }
        // IEnumerable Member
        public IEnumerator<KeyValuePair<int, string>> GetEnumerator()
        {
            foreach (KeyValuePair<int, string> o in dctIdName)
            {
                yield return o;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
