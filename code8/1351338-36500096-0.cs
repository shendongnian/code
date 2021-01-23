    class _Class
        {
            public string name;
            public void myMethod()
            {
                int i;
                string s = "asda";
                i = int.Parse(s);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    _Class blah = new _Class();
                    blah.name = "Steve";
                    blah.myMethod();
                }
               catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.ReadLine();
            }
