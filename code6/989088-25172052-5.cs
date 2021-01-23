    public struct Test 
    {
        public string str { get; private set; }
        public int int1 { get; private set; }
        public Test(string str, int int1) : this()
        {
            this.str = str;
            this.int1 = int1;
        }
    }
    // if you introduce methods (other than constructors) that use the private setters,
    // the struct will no longer be immutable
