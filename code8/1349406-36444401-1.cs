    class StringSet
    {
        private List<List<string>> _Buckets;
        private int _numStrings;
        public StringSet()
        {
            this._Buckets = new List<List<string>>();
            this._numStrings = 0;
        }
        public StringSet(string[] S)
        {
            // better way to do this?
            this._Buckets = new List<List<string>>();
            foreach (string s in S) this._Buckets.Add(new List<string>());
            foreach (string s in S) { this.Insert(s); ++_numStrings; }
        }
        private int _GetBucketNumber(string s, List<List<string>> Buckets)
        {
            //       s: string whose index to look up
            // Buckets: source buckets
            // disallow empty or NULL strings
            if (String.IsNullOrEmpty(s)) { throw new ArgumentException("Cannot add empty or NULL string to set"); }
            if (Buckets.Count == 0) { throw new ArgumentException("Tried to call _GetBucketNumber on empty bucket list"); }
            // XOR characters together and mod by length of buckets
            char c = s[0];
            for (int i = 1; i < s.Length; ++i)
            {
                c ^= s[i];
            }
            return (int)c % Buckets.Count;
        }
        private void _RehashIfNecessary()
        {
            // if the number of strings in the set exceeds the number of buckets, 
            // increase the number of buckets to either double its current size 
            // or the largest number of buckets possible, whichever is smaller
            if (this._numStrings > this._Buckets.Count)
            {
                List<List<string>> NewBuckets = new List<List<string>>(_numStrings++);
                foreach (List<string> Bucket in this._Buckets)
                {
                    NewBuckets.Add(new List<string>(Bucket));
                }
                this._Buckets = NewBuckets;
            }
        }
        public void Insert(string s)
        {
            // disallow empty or NULL strings
            if (String.IsNullOrEmpty(s)) { throw new ArgumentException("Cannot add empty or NULL string to set"); }
            // Get bucket that string belongs in
            List<string> Bucket = this._Buckets[this._GetBucketNumber(s, this._Buckets)];
            // Add if not already there
            if (Bucket.IndexOf(s) == -1)
            {
                Bucket.Add(s);
            }
            ++_numStrings;
            _RehashIfNecessary();
        }
        public bool Contains(string s)
        {
            // returns true or false depending on whether s is a 
            // string currently in the set
            return (this._Buckets[this._GetBucketNumber(s, this._Buckets)].IndexOf(s) != -1);
        }
        public void Print()
        {
            int j;
            //checking the bucket
            for (int i = 0; i < this._Buckets.Count; i++)
            {
                if (_Buckets[i].Count == 0)
                    Console.Write($"Bucket {i}: Empty!");
                else
                {
                    Console.Write("Bucket {0}: ", i);
                    //Checking items within the bucket
                    for (j = 0; j < _Buckets[i].Count; j++)
                    {
                        Console.Write($"[{this._Buckets[i].ToArray().GetValue(j).ToString()}] ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] strs = new string[] { "apple", "potato", "car", "cat", "dog", "sheep", "Trump" };
            StringSet TestSet = new StringSet(strs);
            TestSet.Print();
            Console.Read();
        }
    }
