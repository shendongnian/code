        static void Main(string[] args)
        {
            bool a = true;
            bool b = true;
            bool c = true;
            string x = "";
            string Test = x + (a ? "Clear" : "") + (b ? "Permanent" : "") + (c ? "Salaried" : "");
            Console.WriteLine(Test);
            Console.ReadLine(); //so that my console window doesn't close
        }
          
