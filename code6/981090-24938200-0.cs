    public class RandomClass
    {
        public string Foo { get; set; }
        [Ignore]
        public int Bar { get; set; }
    }
    public class IgnoreAttribute : Attribute
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var properties = typeof(RandomClass).GetProperties()
                            .Where(prop => !prop.IsDefined(typeof(IgnoreAttribute), false));
            // Serialize all values
        }
    }
