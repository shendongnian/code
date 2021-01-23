        static void Main(string[] args)
        {
            var variable1 = "1";
            var variable2= 90056;
            var variable3 = 'u';
            
            // random order
            TestMethod(arg3: variable3, arg1: variable1, arg2: variable2);
            // you can even omit some argument
            TestMethod(arg2: variable2);
        }
        private static void TestMethod(string arg1 = null, int arg2 = 0, char arg3 = '\0')
        {
            Console.WriteLine(arg1);
            Console.WriteLine(arg2);
            Console.WriteLine(arg3);
            Console.ReadKey();
        }
