    class Program
    {
        static void Main(string[] args)
        {
            //When no scope defined
            DemoClass alone1 = new DemoClass();
            DemoClass alone2 = new DemoClass();
            Console.WriteLine(DemoClass.ScopeObjects.Count());
            //When scope is defined
            DemoClass.StartScope();
            DemoClass demo1 = new DemoClass { a = 10, b = 20 };
            DemoClass demo2 = new DemoClass { a = 11, b = 22 };
            Console.WriteLine(DemoClass.ScopeObjects.Count());
            
            //Here is your for each
            foreach (var item in DemoClass.ScopeObjects)
            {
                Console.WriteLine(item.Sum());
            }
            DemoClass.EndScope();
                        
            Console.ReadKey();
        }
