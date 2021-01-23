    public abstract class Fruit
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
    }
    public class Apple : Fruit
    {
        public string Name { get { return "Apple"; }
        public string Description { get { return "The green apples are very green."; }
    }
    public class Orange : Fruit
    {
        public string Name { get { return "Orange"; }
        public string Description { get { return "Sunkist oranges are very sweet."; }
    }
