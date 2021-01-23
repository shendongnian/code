        private Dictionary<string, Func<string,string>> Handle;
        private string ReturnRate;
        public data()
        {
            Handle = new Dictionary<string, Func<string,string>>();
            Add(ref ReturnRate);
            Handle["1"]("MyValue");
            
            Console.WriteLine(ReturnRate);
        }
        public void Add(ref string rate)
        {
          string somevalue=rate;
            Handle.Add("1", (m) =>
            {
                 Console.WriteLine(m);
                somevalue= m;
                return m;
            });
            
        }
