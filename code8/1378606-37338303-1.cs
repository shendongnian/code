    using System;
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var electrodomestico = new Electrodomestico();
                var lavadora = new Lavadora();
                var television = new Television();
                var objects = new iSaveable[]{ electrodomestico, lavadora, television };
                foreach(var ob in objects)
                    ob.Save();
                Console.ReadLine();
            }
        }
    }
