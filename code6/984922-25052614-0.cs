    class Program
    {
        static void Main(string[] args)
        {
             List<string> _list = new List<string>(); //Declare an empty list like this.
            _list.Add("string1");                     //Add a string to it like this.
            string valueOfString2 = "string2";
            _list.Add(valueOfString2);                //Or like this.
            _list.Add("string3");
            foreach (string item in _list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
