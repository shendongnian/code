    // put in the interface
    class Test : IEnumerable<int>
    {
        private Dictionary<int, string> dict
            = new Dictionary<int, string>();
        public IEnumerator<int> GetEnumerator()
        {
            return dict.Keys.GetEnumerator();
        }
        public Test()
        {
            dict[1] = "test";
            dict[2] = "nothing";
        }
        public IEnumerable<int> SortedKeys
        {
            get { return this.OrderBy(x => x); } // illegal!
        }
        public void Print()
        {
            foreach (var key in this)
                Console.WriteLine(dict[key]);
        }
        // this one is required according to the interface too
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
