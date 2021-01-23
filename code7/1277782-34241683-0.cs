    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[,] data = new int[,] {
                    {5, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    {2 ,2, 4, 5, 6, 7, 8, 8, 9, 9},
                    {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    {2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
                    {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                    {5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
                    {4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                    {7, 7, 7, 7, 7, 7, 7, 7, 7, 7},
                    {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                    {1, 1, 1, 1, 1, 1, 1, 11, 1, 1}
                };
                int[] sum = new int[10];
                for (int row = 0; row < 10; row++)
                {
                    for (int col = 0; col < 10; col++)
                    {
                        if (row == 0)
                        {
                            sum[col] = data[row, col];
                        }
                        else
                        {
                            sum[col] += data[row, col];
                        }
                    }
                }
                 List<List<int>> data2 = new List<List<int>>() {
                    new List<int>() {5, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    new List<int>() {2 ,2, 4, 5, 6, 7, 8, 8, 9, 9},
                    new List<int>() {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                    new List<int>() {2, 2, 2, 2, 2, 2, 2, 2, 2, 2},
                    new List<int>() {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                    new List<int>() {5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
                    new List<int>() {4, 4, 4, 4, 4, 4, 4, 4, 4, 4},
                    new List<int>() {7, 7, 7, 7, 7, 7, 7, 7, 7, 7},
                    new List<int>() {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                    new List<int>() {1, 1, 1, 1, 1, 1, 1, 11, 1, 1}
                };
                
                //using linq
                int[] sum2 = data2.Select(s => s.Select((t, i) => new { num = t, col = i })).SelectMany(u => u).GroupBy(v => v.col).ToList().Select(w => w.Select(x => x.num).Sum()).ToArray();
                 
            }
        }
    }
    ​
