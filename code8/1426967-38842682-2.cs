        private static Task Handler1()
        {
            var t1 = DoSomething2();
            var t2 = DoSomething3();
            return Task.WhenAll(t1, t2); //You could return the task or await here itself 
        }
        private static Task DoSomething2()
        {
            Console.WriteLine("DoSomethign 2");
            return Task.Delay(3000);
        }
        private static Task DoSomething3()
        {
            Console.WriteLine("DoSomethign 3");
            return Task.Delay(3000);
        }
