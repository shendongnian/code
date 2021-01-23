    using System;
    using System.Linq;
    
        namespace TestConsole
        {
            class Program
            {
                static void Main(string[] args)
                {
                    // tests
                    var A = new int[] { -122, -5, 1, 2, 3, 4, 5, 6, 7 }; // 8
                    var B = new int[] { 1, 3, 6, 4, 1, 2 }; // 5
                    var C = new int[] { -1, -3 };  // 1
                    var D = new int[] { -3 };  // 1
                    var E = new int[] { 1 };  // 2
                    var F = new int[] { 1000000 };  // 1
        
        
                    var x = new int[][] { A, B, C, D, E, F };
        
                    x.ToList().ForEach((arr) =>
                    {
                        var s = new Solution();
                        Console.WriteLine(s.solution(arr));
                    });
        
                    Console.ReadLine();
                }
            }
        
            class Solution
            {
                public int solution(int[] A)
                {
                    A = A.Where(entry => entry > 0).Distinct().ToArray();
                    Array.Sort(A);
                    int lowest = 1;
                    int aLength = A.Length;
                    int highestIndex = aLength - 1;
        
                    for (int i = 0; i < aLength; i++)
                    {
                        var currInt = A[i];               
                        if (currInt > lowest) return lowest;
                        if (i == highestIndex) return ++lowest;
                        lowest++;              
                    }
                    return 1;
                }
            }
        }
