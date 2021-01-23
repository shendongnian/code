    using System;
    using System.Linq;
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter 1 or more numbers separated by space in between. I.e. 1 2\nAny non numerical will be treated as 0:");
            var str = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Sorry, expecting 1 or more numbers separated by space in betwen. I.e. 5 6 8 9");
            }
            else
            {
                var tokens = str.Split(' ');
                var result = tokens
                    .Select(t =>
                    {
                        int i;
                        if (int.TryParse(t, out i))
                        {
                            Console.WriteLine("Valid Number Detected: {0}", i);
                        };
                        return i;
                    })
                    .Aggregate(0, (s, t) => s + t);
                Console.WriteLine("Sum of all numbers is {0}", result);
            }
    
            Console.ReadLine();
        }
    }
