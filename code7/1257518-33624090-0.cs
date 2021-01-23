    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var string1 = "Hi thar im a string";
                var string2 = "Hi thar im a string";
                var string3 = "Hi thar im a similar string";
                var string4 = "im a really different string";
                var string5 = "Hi thar im a string but have many different words";
                Console.WriteLine(StringComparo(string1, string2));
                Console.WriteLine(StringComparo(string1, string3));
                Console.WriteLine(StringComparo(string1, string4));
                Console.WriteLine(StringComparo(string1, string5));
                Console.ReadLine();
            }
            public static bool StringComparo(string str1, string str2, int diffCounterLimiter = 3)
            {
                var counter = 0;
                var arr1 = str1.Split(' ');
                var arr2 = str2.Split(' ');
                while (counter <= diffCounterLimiter)
                {
                    TreeNode bestResult = null;
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        for (int j = 0; j < arr2.Length; j++)
                        {
                            var result = new TreeNode() { arr1Index = i, arr2Index = j };
                            if (string.Equals(arr1[i], arr2[j]) && (bestResult == null || bestResult.diff < result.diff))
                            {
                                bestResult = result;
                            }
                        }
                    }
                    // no result found
                    if(bestResult == null)
                    {
                        // any left over words plus current counter
                        return arr1.Length + arr2.Length + counter <= diffCounterLimiter;
                    }
                    counter += bestResult.diff;
                    arr1 = arr1.Where((val, idx) => idx != bestResult.arr1Index).ToArray();
                    arr2 = arr2.Where((val, idx) => idx != bestResult.arr2Index).ToArray();
                }
                return false;
            }
        }
        public class TreeNode
        {
            public int arr1Index;
            public int arr2Index;
            public int diff => Math.Abs(arr1Index - arr2Index);
        }
    }
