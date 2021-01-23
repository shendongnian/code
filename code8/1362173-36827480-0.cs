    // Assembly: A
    public interface IExample
    {
        string Name { get; }
    }
    // Assembly: B
    using A;
    public abstract class Example : IExample
    {
        public string Name { get; protected internal set; }
    }
    public class SpecificExample : Example
    {
        public void UpdateName(string name)
        {
            // Can be set because it has protected accessor
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IExample e = new SpecificExample()
            {
                // Can be set because it has internal accessor
                Name = "OutsideAssemblyA"
            };
        }
    }
    // Assembly: C
    using A;
    public abstract class Example : IExample
    {
        public string Name { get; protected internal set; }
    }
    public class AnotherSpecificExample : Example
    {
        public void UpdateName(string name)
        {
            // Can be set because it has protected accessor
            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IExample e = new AnotherSpecificExample()
            {
                // Can be set because it has internal accessor
                Name = "OutsideAssemblyA"
            };
        }
    }
