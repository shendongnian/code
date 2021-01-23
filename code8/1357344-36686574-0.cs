    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection;
    
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new { Foo = "Fred", Bar = "Baz" };
            dynamic d = CreateExpandoFromObject(obj);
            d.Other = "Hello";
            Console.WriteLine(d.Foo);   // Copied
            Console.WriteLine(d.Other); // Newly added
        }
        
        static ExpandoObject CreateExpandoFromObject(object source)
        {
            var result = new ExpandoObject();
            IDictionary<string, object> dictionary = result;
            foreach (var property in source
                .GetType()
                .GetProperties()
                .Where(p => p.CanRead && p.GetMethod.IsPublic))
            {
                dictionary[property.Name] = property.GetValue(source, null);
            }
            return result;
        }
    }
