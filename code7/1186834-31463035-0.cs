    using System;
    
    class Fruit
    {
        public string Name { get; set; }
    }
    
    class Apple : Fruit
    {
        public string Name { get; set; }
    }
    
    
    class Test
    {
        static void Main()
        {
            var apple = new Apple { Name = "AppleName" };
            Fruit fruit = apple;
            Console.WriteLine(fruit.Name); // Nothing!
            fruit.Name = "FruitName";
            Console.WriteLine(((Fruit) apple).Name); // FruitName
            Console.WriteLine(((Apple) fruit).Name); // AppleName
        }
    }
