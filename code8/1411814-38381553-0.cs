    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class Test {
        static IEnumerable<int> KeepNoMoreThen(this IEnumerable<int> source, int limit) {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach(int current in source) {
                int count;
                counts.TryGetValue(current, out count);
                if(count<limit) {
                    counts[current]=count+1;
                    yield return current;
                }
            }
        }
        static void Main() {
            int[] arr = new int[] { 1, 2, 1, 4, 5, 1, 2, 2, 2 };
            int occurrenceLimit = 2;
            List<int> result = arr.KeepNoMoreThen(occurrenceLimit).ToList();
            result.ForEach(Console.WriteLine);
        }
    }
