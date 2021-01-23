    class Program
    {
        static void Main(string[] args)
        {
            List<ISpecies> species = new List<ISpecies>();
            species.Add(new Cat());
            species.Add(new Dog());
            foreach (var specie in species)
            {
                Console.WriteLine(specie.ClassProp);
                Console.WriteLine(specie.DatabaseProp);
            }
            Console.Read();
        }
        public interface ISpecies
        {
            string ClassProp { get; }
            string DatabaseProp { get; }
        }
        public class Cat : ISpecies
        {
            public string ClassProp { get { return "Cat Class Property"; } }
            public string DatabaseProp { get { return "Cat Database Propery"; } }
        }
        public class Dog : ISpecies
        {
            public string ClassProp { get { return "Dog Class Property"; } }
            public string DatabaseProp { get { return "Dog Database Propery"; } }
        }
    }
