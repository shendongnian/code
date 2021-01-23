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
                int skip = 0; // Index of item to omit from recursive call.
                return
                    from item in seq
                    from permOfRemainder in seq.Count() == 1 ? new[]{new T[0]} : Permute(allExcept(seq, skip++))
                    select new[]{item}.Concat(permOfRemainder);
            }
            static IEnumerable<T> allExcept<T>(IEnumerable<T> seq, int indexToSkip)
            {
                return 
                    from item in seq.Select((item, index) => new {item, index})
                    where item.index != indexToSkip select item.item;
            }
        }
    }
