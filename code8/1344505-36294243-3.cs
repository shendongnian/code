    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void Main()
            {
                //var indices = FindTwoSum(new List<int> { 1, 3, 5, 7, 9 }, 12);
                //Console.WriteLine(indices.Item1 + " " + indices.Item2);
                //indices = FindTwoSumInSortedList(new List<int> { 1, 3, 5, 7, 9 }, 12);
                //Console.WriteLine(indices.Item1 + " " + indices.Item2);
                int n = 10000000;
                int[] array = new int[n];
                var rng = new Random(18789);
                for (int i = 0; i < n; ++i)
                    array[i] = rng.Next(0, n);
                array[n/2] = n;
                array[n/2 + 1] = n+1;
                var sw = Stopwatch.StartNew();
           
                // This is too slow to test:
                //var result = FindTwoSum(array, n*2+1);
                //Console.WriteLine(sw.ElapsedMilliseconds);
                //Console.WriteLine(result);
                sw.Restart();
                var result = FindTwoSumFaster(array, n*2 + 1);
                Console.WriteLine(sw.ElapsedMilliseconds);
                Console.WriteLine(result);
                sw.Restart();
                var indices = Enumerable.Range(0, n).ToArray();
                Array.Sort(array, indices);
                result = FindTwoSumInSortedList(array, indices, n*2+1);
                Console.WriteLine(sw.ElapsedMilliseconds);
                Console.WriteLine(result);
            }
            public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    int sum2 = sum - list[i];
                    int index = list.IndexOf(sum2);
                    if (index > 0)
                    {
                        return new Tuple<int, int>(i, index);
                    }
                }
                return null;
            }
            public static Tuple<int, int> FindTwoSumInSortedList(IList<int> list, int[] indices, int sum)
            {
                for (int i = 0, j = list.Count - 1; i < j;)
                {
                    int s = list[i] + list[j];
                    if (s == sum)
                        return new Tuple<int, int>(indices[i], indices[j]);
                    else if (s < sum)
                        ++i;
                    else
                        --j;
                }
                return null;
            }
            public static Tuple<int, int> FindTwoSumFaster(IList<int> list, int sum)
            {
                if (list == null)
                    throw new NullReferenceException("Null list");
                // constructing a hashset to have O(1) operations
                var listSet = new HashSet<int>();
                // number -> index mapping
                // O(n) complexity
                var listReverseSet = new Dictionary<int, int>();
                int i = 0;
                foreach (var elem in list)
                {
                    if (!listSet.Contains(elem))
                        listSet.Add(elem);
                    listReverseSet[elem] = i++;
                }
                // O(n) complexity
                int listCount = list.Count;
                for (int index = 0; index < listCount; index++)
                {
                    var elem = list[index];
                    if (listSet.Contains(sum - elem))
                        return new Tuple<int, int>(index, listReverseSet[sum - elem]);
                }
                return null;
            }
        }
    }
