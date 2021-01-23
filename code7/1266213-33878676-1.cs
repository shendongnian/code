    class Program
    {
        abstract class Position
        {
            public abstract string Title { get; }
        }
        class Manager : Position
        {
            public override string Title
            {
                get
                { return "Manager"; }
            }
        }
        class Clerk : Position
        {
            public override string Title
            {
                get
                { return "Clerk"; }
            }
        }
        class Programmer : Position
        {
            public override string Title
            {
                get
                { return "Programmer"; }
            }
        }
        static class Factory
        {
            public static T Create<T>() where T : Position, new ()
            {
                return new T();
            }
        }
        static void Main(string[] args)
        {
            List<Position> positions = new List<Position>(3);
            positions.Add(Factory.Create<Manager>());
            positions.Add(Factory.Create<Clerk>());
            positions.Add(Factory.Create<Programmer>());
            Console.ReadLine();
        }
    }
