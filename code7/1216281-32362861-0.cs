    class Test
    {
        private string _a;
        private int _b;
        public Test(string a, int b)
        {
	       _a = a;
	       _b = b;
        }
       public override string ToString()
       {
	      return string.Format("{0}, {1}", _a, _b);
       }
    }
