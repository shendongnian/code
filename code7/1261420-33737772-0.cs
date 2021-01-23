    void Main()
    {
        Console.WriteLine (Foo.Bar.GetAttribute<ExampleAttribute>().Name);
        // Outputs > random name
    }
    
    public enum Foo
    {
        [Example("random name")]
        Bar
    }
    
    [AttributeUsage(AttributeTargets.All)]
    public class ExampleAttribute : Attribute
    {
        public ExampleAttribute(string name)
        {
            this.Name = name;
        }
    
        public string Name { get; set; }
    }
    
    public static class Extensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }
    // Define other methods and classes here
