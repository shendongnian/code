    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication85
    {
        class Program
        {
            static void Main(string[] args)
            {
                int index = 0;
                List<string> list1 = null;
                List<string> list2 = null;
                Dictionary<string,int> dict1  = new Dictionary<string,int>()  { 
                    {"A", 5},
                    {"B", 2},
                    {"C", 3},
                    {"D", 4},
                    {"E", 1}
                };
                index = ReturnSmallestDiffIndex(dict1.AsEnumerable().Select(x => x.Value).ToList());
                list1 = dict1.AsEnumerable().Take(index).Select(x => x.Key).ToList();
                list2 = dict1.AsEnumerable().Skip(index).Take(dict1.Count - index).Select(x => x.Key).ToList();
                Dictionary<string, int> dict2 = new Dictionary<string, int>()  { 
                    {"A", 1},
                    {"B", 1},
                    {"C", 1},
                    {"D", 1},
                    {"E", 9}
                };
      
                index = ReturnSmallestDiffIndex(dict2.AsEnumerable().Select(x => x.Value).ToList());
                list1 = dict1.AsEnumerable().Take(index).Select(x => x.Key).ToList();
                list2 = dict1.AsEnumerable().Skip(index).Take(dict1.Count - index).Select(x => x.Key).ToList();
            }
            static int ReturnSmallestDiffIndex(List<int> input)
            {
                SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();
                for(int index = 1; index < input.Count; index++)
                {
                    int diff = input.Skip(index).Take(input.Count - index).Sum() - input.Take(index).Sum();
                    if(dict.ContainsKey(Math.Abs(diff)))
                    {
                        dict[Math.Abs(diff)].Add(index);
                    }
                    else
                    {
                       dict.Add(Math.Abs(diff), new List<int>() {index});
                    }
                }
                return dict.AsEnumerable().FirstOrDefault().Value.FirstOrDefault();
            }
        }
    }
