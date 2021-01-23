    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    enum Color
    {
        Red = 1,
        Green = 1,
        Blue = 1,
        Yellow = 2,
        Cyan = 2,
        Purple = 2
    }
    
    class Test
    {
        static void Main()
        {
            foreach (var name in GetColorNames(1))
            {
                Console.WriteLine(name);
            }
        }
        
        static IEnumerable<string> GetColorNames(int value)
        {
            return Enum.GetNames(typeof(Color))
                       .Where(name => (int) Enum.Parse(typeof(Color), name) == value);
        }
    }
