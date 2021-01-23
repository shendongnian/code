    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace SO30229368
    {
        class Program
        {
            private const string NullItem = "null";
    
            static void Main(string[] args)
            {
                var periodList = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(NullItem, "1/12"),
                    new Tuple<string, string>("2/12", NullItem),
                    new Tuple<string, string>(NullItem, "4/12"),
                    new Tuple<string, string>("6/12", "8/12"),
                    new Tuple<string, string>("9/12", NullItem),
                    new Tuple<string, string>(NullItem, "10/12"),
                    new Tuple<string, string>("11/12", NullItem)
                };
    
                var consecutiveList = GetConsecutive(periodList);
                foreach (var tupleItem in consecutiveList)
                    Console.WriteLine("{0} - {1}", tupleItem.Item1, tupleItem.Item2);
    
                Console.ReadLine();
            }
    
            private static IEnumerable<Tuple<string, string>> GetConsecutive(List<Tuple<string, string>> periodList)
            {
                if (periodList == null)
                    throw new ArgumentNullException("periodList");
                if (periodList.Count == 0)
                    return new List<Tuple<string, string>>();
    
                var startList = periodList.Select(x => x.Item1).Where(y => y != NullItem).ToList();
                if (periodList.First().Item1 == NullItem)
                    startList.Insert(0, NullItem);
                var endList = periodList.Select(x => x.Item2).Where(y => y != NullItem).ToList();
                if (periodList.Last().Item2 == NullItem)
                    endList.Add(NullItem);
    
                Debug.Assert(startList.Count == endList.Count);
                return Enumerable.Zip(startList, endList, (start, end) => new Tuple<string, string>(start, end)).ToList();
            }
        }
    }
