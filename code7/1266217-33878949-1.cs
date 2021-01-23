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
    
        class Factory
        {
            private List<IPosition> positions = new List<IPosition>();
            public Factory()
            {
                positions.Add(new Manager());
                positions.Add(new Clerk());
                positions.Add(new Programmer());
                positions.Add(new Programmer());
            }
    
            public IPosition GetPositions(int id)
            {
                return positions[id];
            }
        }
    
        static void Main(string[] args)
        {
            Factory factory = new Factory();
    
            for (int i = 0; i <= 2; i++)
            {
                var position = factory.GetPositions(i);
                Console.WriteLine("Where id = {0}, position = {1} ", i, position.Title);
            }
            Console.ReadLine();
        }
    }
