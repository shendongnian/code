    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Demo
    {
        internal class Program
        {
            [STAThread]
            private static void Main(string[] args)
            {
                SortedDictionary<int, List<int>> tempRepositary = new SortedDictionary<int, List<int>>();
                tempRepositary.Add(2, new List<int>(new[] { 2, 3, 6, 7 }));
                tempRepositary.Add(3, new List<int>(new[] { 3, 5 }));
                tempRepositary.Add(5, new List<int>(new[] { 5, 7, 9 }));
                tempRepositary.Add(11, new List<int>(new[] { 11, 12, 12 }));
    
                var refreshOne = SortTree(tempRepositary);
    
                foreach (var item in refreshOne.Keys)
                {
                    Console.Write("Key:" + item + " ");
    
                    List<int> values;
                    if (refreshOne.TryGetValue(item, out values))
                    {
                        Console.WriteLine(string.Join(",", values));
                    }
                }
    
                Console.ReadKey();
            }
    
            private static SortedDictionary<int, List<int>> SortTree(SortedDictionary<int, List<int>> trees)
            {
                if (trees.Count < 2) { return trees; }  // dont process if ntrees contains 1 or 0 trees
    
                int CompressRatio = 3;
    
                SortedDictionary<int, List<int>> compressedTree
                    = new SortedDictionary<int, List<int>>();
    
                int IndexToRemember = 0;
                int TotalIteration = trees.Count / CompressRatio;
    
                if (trees.Count % CompressRatio > 0)
                {
                    TotalIteration++;
                }
    
                List<int> tempValues = new List<int>();
                List<int> tempKeys = new List<int>();
                List<int> keyList = new List<int>(trees.Keys);
    
                for (int i = 0; i < TotalIteration; i++)
                {
                    //If last itearation
                    if (i == TotalIteration - 1)
                    {
                        CompressRatio = trees.Count - IndexToRemember;
                    }
    
                    for (int j = 0; j < CompressRatio; j++)
                    {
                        int tempKey = keyList[IndexToRemember++];
                        tempKeys.Add(tempKey);
    
                        List<int> values;
                        if (trees.TryGetValue(tempKey, out values))
                        {
                            tempValues.AddRange(values);
                        }
                    }
    
                    compressedTree.Add(tempKeys.Min(), tempValues.Distinct().OrderBy(i1 => i1).ToList());
    
                    tempKeys.Clear();
                    tempValues.Clear();
                }
    
                return compressedTree;
            }
        }
    }
