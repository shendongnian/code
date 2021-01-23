    using System;
    using System.Collections.Generic;
    namespace SplitList
    {
        class Program
        {
            static void Main(string[] args)
            {
                var list = new List<int> { 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1 };
                List<List<int>> splitSequences = new List<List<int>>();
                List<int> curSequence = new List<int>();
                foreach (var item in list)
                {
                    if (item == 1) {
                        curSequence.Add(item);
                    } else {
                        //Only push the current sequence onto the list of sequences if it is not empty,
                        //which could happen if multiple zeroes are encountered in a row
                        if (curSequence.Count > 0) {
                            splitSequences.Add(curSequence);
                            curSequence = new List<int>();
                        }
                    }
                }
                //push any final list
                if (curSequence.Count > 0)
                {
                    splitSequences.Add(curSequence);
                }
                foreach (var seq in splitSequences) {
                    String line = String.Join(",", seq);
                    Console.WriteLine(line);
                }
                Console.WriteLine("");
                Console.WriteLine("Press any key to exit");
                var discard = Console.ReadKey();
            }
        }
    }
