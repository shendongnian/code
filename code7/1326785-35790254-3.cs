    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Demo
    {
        public class Example
        {
            public static void Main()
            {
                SortedDictionary<int, List<int>> tempRepositary = new SortedDictionary<int, List<int>>();
    
                //test 1
                tempRepositary.Add(2, new List<int>(new[] { 2, 3, 5, 6, 7 }));
                tempRepositary.Add(5, new List<int>(new[] { 5, 7, 9 }));
                tempRepositary.Add(11, new List<int>(new[] { 11, 12, 12, 27, 30, 31 }));
                tempRepositary.Add(22, new List<int>(new[] { 22, 27 }));
                tempRepositary.Add(23, new List<int>(new[] { 23, 25 }));
                tempRepositary.Add(28, new List<int>(new[] { 28, 30 }));
                tempRepositary.Add(34, new List<int>(new[] { 34 }));
    
                //test 2
                //tempRepositary.Add(2, new List<int>(new[] { 2,3,6,7 }));
                //tempRepositary.Add(3, new List<int>(new[] { 3,5 }));
                //tempRepositary.Add(5, new List<int>(new[] { 5,7,9 }));
                //tempRepositary.Add(11, new List<int>(new[] { 11,12,12 }));
    
                var refreshOne = SortTree(tempRepositary);    
             
                foreach (var item in refreshOne)
                {
                    Console.Write("Key:" + item.Key + " ");
                    Console.WriteLine(string.Join(",", item.Value));                 
                }
    
                Console.ReadKey();
            }
    
            private static SortedDictionary<int, List<int>> SortTree(SortedDictionary<int, List<int>> trees)
            {
                if (trees.Count < 2) { return trees; }  // dont process if ntrees contains 1 or 0 trees
    
                SortedDictionary<int, List<int>> compressedTree
                    = new SortedDictionary<int, List<int>>();
    
                var allKeys = trees.Keys.ToList();
                var allValues = trees.Values.ToList();
    
                for (int i = 0; i < allKeys.Count; i++)
                {
                    var tempValues = allValues[i];
                    var tempMax = tempValues.Max();
    
                    for (int j = i + 1; j < allKeys.Count; )
                    {
                        if (tempMax >= allKeys[j])
                        {
                            tempValues.AddRange(allValues[j]);
                            allKeys.Remove(allKeys[j]);
                            allValues.Remove(allValues[j]);
                            //
                            tempMax = tempValues.Max();
                            continue;
                        }
                        j++;
                    }
    
                    compressedTree.Add(allKeys[i], tempValues.Distinct().OrderBy(i1 => i1).ToList());
                }
    
                return compressedTree;
            }
        }
    }
