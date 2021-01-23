    using System;
    using System.Threading.Tasks;
    
    namespace TaskClass
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Pre A");
                A();
                Console.WriteLine("Post A");
                Console.ReadKey();
            }
            static async Task A()
            {
                Console.WriteLine("pre B");
                await B();
                Console.WriteLine("post B");
            }
    
            static async Task B()
            {
                Console.WriteLine("inside B");
                await Task.Delay(10000);
                Console.WriteLine("still inside B");
            }
    
        }
    }
