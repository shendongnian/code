    class Program
    {
        static void Main(string[] args)
        {
             ListDemo _list = new ListDemo();
             
            List<String> Str=new List<String>();
            Str.Add("string1");
            Str.Add("string2");
            Str.Add("string3");
             
            _list.Str=Str;
          
            foreach (string item in _list.Str)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
    class ListDemo
    {
        string[] _str = new string[3];
        public List<string> Str
        {
            get
            {
                return _str.ToList();
            }
            set
            {
                _str = value.ToArray();
            }
        }
    }
