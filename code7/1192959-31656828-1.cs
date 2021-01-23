    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> values = new List<int>{1, 2, 3, 4};
    
                IEnumerable<int> moreValues = values.TakeOrDefault(3, 100);
                Console.WriteLine(moreValues.Count());
    
                moreValues = values.TakeOrDefault(4, 100);
                Console.WriteLine(moreValues.Count());
    
                moreValues = values.TakeOrDefault(10, 100);
                Console.WriteLine(moreValues.Count());
    
            }
        }
    
        public static class ExtensionMethods
        {
            public static IEnumerable<T> TakeOrDefault<T>(this IEnumerable<T> enumerable, int count, T defaultValue)
            {
                int returnedCount = 0;
                foreach (T variable in enumerable)
                {
                    returnedCount++;
                    yield return variable;
                    if (returnedCount == count)
                    {
                        yield break;
                    }
                }
    
                if (returnedCount < count)
                {
                    for (int i = returnedCount; i < count; i++)
                    {
                        yield return defaultValue;
                    }
                }
            }
        }
    }
