    class A
    {
        public string Id { get; set; }
        public string Value { get; set; }
        
        public A() { }
        public A(string s)
        {
            string[] vals = s.Split((new string[] { "\r\n" }), StringSplitOptions.RemoveEmptyEntries);
            this.Id = vals[0].Replace("Id : ", string.Empty).Trim();
            this.Value = vals[1].Replace("Value : ", string.Empty).Trim();
        }
        // only overridden here for printing
        public override string ToString()
        {
            return string.Format("Id : {0}\r\nValue : {1}\r\n", this.Id, this.Value);
        }
    }
    
