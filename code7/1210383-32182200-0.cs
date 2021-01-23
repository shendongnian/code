    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> input = new List<int>() { 1, 2, 2, 1, 3, 3, 3, 2, 3, 3, 1, 3, 3, 2, 3 };
                int previous = 0;
                int key = 0;
                int keyIndex = 0;
                Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
                for (int i = 0; i < input.Count; i++)
                {
                    if (i == 0)
                    {
                        key = input[0];
                        keyIndex = 0;
                        previous = key;
                    }
                    else
                    {
                        if (input[i] < previous)
                        {
                            key = input[i];
                            keyIndex = i;
                        }
                        else
                        {
                            if (dict.ContainsKey(keyIndex))
                            {
                                dict[keyIndex].Add(i);
                            }
                            else
                            {
                                dict.Add(keyIndex, new List<int>(){ i});
                            }
                        }
                        previous = input[i];
                    }
                }
                foreach (int dictKey in dict.Keys)
                {
                    var l = dict[dictKey];
                    Console.WriteLine("Key:{0}, values={1}", dictKey, string.Join(",", dict[dictKey].Select(x => x.ToString()).ToArray()));
                }
                Console.ReadLine();
            }
        }
    }
    ​
