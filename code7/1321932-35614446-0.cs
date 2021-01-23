    static void Main()
    {
        var test = new Test
        {
            Hobbies =
            {
                 new Hobby { Name = "abc" }
            }
        };
        var clone = Serializer.DeepClone(test);
        Console.WriteLine("Same object? {0}",
            ReferenceEquals(test, clone));
        Console.WriteLine("Sub items: {0}",
            clone.Hobbies.Count);
        foreach (var x in clone.Hobbies)
        {
            Console.WriteLine(x.Name);
        }
    }
