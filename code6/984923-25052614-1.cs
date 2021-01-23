    class Program
    {
        static void Main(string[] args)
        {
            ListDemo _list = new ListDemo();               //Declare an instance of the ListDemo class.
    
            List<string> newStrList = new List<string>();  //Declare a new List<string>.
            newStrList.Add("string1");                     //Add strings like this.
            newStrList.Add("string2");
            newStrList.Add("string3");
    
            _list.Str = newStrList;                        //Add the entire collection at once, like this.
    
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
