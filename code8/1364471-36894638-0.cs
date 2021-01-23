    class Foo
    {
        private readonly ICollection<int> ints1 = new List<int>(); 
        public ICollection<int> Ints1 { get { return this.ints1; } }
    
        public ICollection<int> Ints2 { get { return new List<int>(); } }
    }
