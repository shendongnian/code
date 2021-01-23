    using System;
    using System.Collections.Generic;
    
    class Program
    {
        interface IPosition
        {
            string Title { get; }
        }
    
        class Manager : IPosition
        {
            public string Title
            {
                get { return "Manager"; }
            }
        }
    
        class Clerk : IPosition
        {
            public string Title
            {
                get { return "Clerk"; }
            }
        }
    
        class Programmer : IPosition
        {
            public string Title
            {
                get { return "Programmer"; }
            }
        }
    
        static void Main(string[] args)
        {
            List<IPosition> positions = new List<IPosition> { new Manager(), new Clerk(), new Programmer(), new Programmer() };
    
            for (int i = 0; i <= 2; i++)
            {
                var position = positions[i];
                Console.WriteLine("Where id = {0}, position = {1} ", i, position.Title);
            }
            Console.ReadLine();
        }
    }
