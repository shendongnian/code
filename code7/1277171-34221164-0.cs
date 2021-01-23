    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            var type = typeof(System.Windows.Window);
            var property = type.GetProperty("IsDisposed", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var accessor in property.GetAccessors(nonPublic: true))
            {
                Console.WriteLine($"{accessor.Name}: {accessor.Attributes}");
            }
        }
    }
