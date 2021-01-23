    public class Workshop
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
         // Visual Studio 2015 / C#6.0 syntax.
        public override string ToString() => $"{Name} ({Price:c})";
    }
