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
                var objects = new ICommonPriceFunctions[]{ electrodomestico, lavadora, television };
                foreach(var ob in objects){
                    var finalPrice = ob.FinalPrice();
                }
                Console.ReadLine();
            }
        }
    }
