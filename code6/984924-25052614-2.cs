    class Program
    {
        static void Main(string[] args)
        {
             List<string> _list = new List<string>(); //Declare an empty list like this.
            _list.Add("string1");                     //Add a string to it like this.
            _list.Add("string2");
            string valueOfString3 = "string3";
            _list.Add(valueOfString3);                //Or like this.
            foreach (string item in _list)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
