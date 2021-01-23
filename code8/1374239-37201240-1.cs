        static void Main(string[] args)
        {
            var variable1 = "1";
            var variable2= 90056;
            var variable3 = 'u';
            TestMethod(arg2: variable2, arg3: variable3, arg1: variable1);
        }
        private static void TestMethod(string arg1, int arg2, char arg3)
        {
            Console.WriteLine(arg1);
            Console.WriteLine(arg2);
            Console.WriteLine(arg3);
            Console.ReadKey();
        }
