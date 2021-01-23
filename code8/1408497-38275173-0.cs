    class MyClass
    {
        public uint myLength { get; set; }
        public uint myPageSize { get; set; }
    
        # note the modified signature
        public IEnumerable<Page> GetPages()
        {
            for (uint i = 1; i < this.myLength; i++)
            {
                Page p;
                try
                {
                    p = new Page(this, i);
                }
                catch (ArgumentOutOfRangeException)
                {
                    yield break;
                }
                yield return p;
            }
        }
    }
