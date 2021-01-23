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
    
                int CompressRatio = 2;
    
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
    
                for (int i = 0; i < TotalIteration && keyList.Count > IndexToRemember; i++)
                {
                    //If last itearation
                    if (i == TotalIteration - 1)
                    {
                        CompressRatio = trees.Count - IndexToRemember;
                    }
    
                    PrepareSortedListValues(trees, CompressRatio, ref IndexToRemember, ref tempValues, ref tempKeys, ref keyList);
    
                    //Edit
                    //after processing recheking if value contains high value
                    //then keys that are not included in this iteration
                    var allDistictTempValues = tempValues.Distinct().OrderBy(i1 => i1).ToList();
                    int MaxOnValues = allDistictTempValues.Max();
                    var LessOfMaxOnValueKeys = keyList.SkipWhile(m => m > MaxOnValues);
                    var LessOfMaxOnValue = LessOfMaxOnValueKeys.Max();
    
                    if (LessOfMaxOnValueKeys != null && LessOfMaxOnValue > MaxOnValues)
                    {
                        var tempCompressRatio = keyList.IndexOf(LessOfMaxOnValue) - IndexToRemember;
                        PrepareSortedListValues(trees, tempCompressRatio, ref IndexToRemember, ref tempValues, ref tempKeys, ref keyList);
                    }
                    //end edit
                    //
                    compressedTree.Add(tempKeys.Min(), allDistictTempValues);
    
                    tempKeys.Clear();
                    tempValues.Clear();
                }
    
                return compressedTree;
            }
    
            private static int PrepareSortedListValues(SortedDictionary<int, List<int>> trees,
                int CompressRatio, ref int IndexToRemember, ref List<int> tempValues, ref List<int> tempKeys, ref List<int> keyList)
            {
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
                return IndexToRemember;
            }
        }
    }
