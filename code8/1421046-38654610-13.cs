    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main()
            {
                List<String> items = new List<String>();
                items.AddRange(new String[] { "a", "b", "c", "d", "e", "f" });
                int i = 0;
                foreach (var permutation in Permute(items))
                    Console.WriteLine(++i + ": " + string.Join(" ", permutation));
            }
            public static IEnumerable<IEnumerable<T>> Permute<T>(IEnumerable<T> seq)
            {
                return
                    from item in seq.Select((value, index) => new {value, index})
                    from remainder in seq.Count() == 1 ? new[]{new T[0]} : Permute(allExcept(seq, item.index))
                    select new[]{item.value}.Concat(remainder);
            }
            static IEnumerable<T> allExcept<T>(IEnumerable<T> seq, int indexToSkip)
            {
                return 
                    from item in seq.Select((value, index) => new {value, index})
                    where item.index != indexToSkip 
                    select item.value;
            }
        }
    }
