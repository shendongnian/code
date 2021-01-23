     class Program
    {
        static void Main(string[] args)
        {
            string[] setA = new string[3] {"1", "2", "3"};
            string[] setB = new string[3] { "a", "b", "c" };
            foreach (string val1 in setA) {
                foreach (string val2 in setB) {
                    Program test = new Program();
                    String printer = test.concatString(val1, val2);
                    Console.WriteLine(printer);
                    
                }
            }
            Console.ReadLine();
        }
        public string concatString(string value1, string value2) {
             String value3 = value1 + value2;
             return value3;
        }
    }
