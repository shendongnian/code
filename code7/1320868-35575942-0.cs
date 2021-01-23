    public class myClass
    {
        private string _a, _b;
        public myClass(string args)
        {
            _a = args.Split(',')[0];
            _b = args.Split(',')[1];
        }
        public string A { get { return _a; } set { _a = value; } }
        public string B { get { return _b; } set { _b = value; } }
        //and so on
    }
