    enum Color { Red = 1, Green, Blue }
    enum Theme { Dark = 1, Light, NotSure }
    public static void Main(string[] args)
    {
        var elements = new[]
        {
            new { Value = 1, Type = typeof(Color) },
            new { Value = 2, Type = typeof(Theme) },
            new { Value = 3, Type = typeof(Color) },
            new { Value = 1, Type = typeof(Theme) },
            new { Value = 2, Type = typeof(Color) },
        };
        foreach (var element in elements)
        {
            var enumValue = Enum.ToObject(element.Type, element.Value);
            Console.WriteLine($"{element.Type.Name}({element.Value}) = {enumValue}");
        }
    }
