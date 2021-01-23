    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace ConsoleApplication9
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Random rand = new Random();
                int maxColumnLength = 10;
                int rowNumber = 100000;
                int colNumber = 300;
                List<string[]> input = new List<string[]>();
                for (int i = 0; i < rowNumber; i++)
                {
                    string[] row = new string[colNumber];
                    for (int j = 0; j < colNumber; j++)
                        row[j] = new string('x', rand.Next(maxColumnLength));
                    input.Add(row);
                }
                var result = Time(SimpleIteration, input, "Simple Iteration");
                var result2 = Time(SimpleIterationWithLinq, input, "Simple Iteration LINQ");
                var result3 = Time(AcceptedAnswer, input, "Accepted Answer");
                var result4 = Time(TomDoesCode, input, "TomDoesCode");
                //var result5 = Time(Kobi, input, "Kobi"); //StackOverflow
                var result6 = Time(Konamiman, input, "Konamiman");
                var result7 = Time(RahulSingh, input, "RahulSingh");
                System.Console.ReadLine();
            }
            private static List<int> SimpleIteration(List<string[]> input)
            {
                int[] maxPerColumn = new int[input.First().Length];
                for (int i = 0; i < maxPerColumn.Length; i++)
                    maxPerColumn[i] = -1;
                foreach (var row in input)
                {
                    for (int i = 0; i < row.Length; i++)
                        if (maxPerColumn[i] < row[i].Length)
                            maxPerColumn[i] = row[i].Length;
                }
                return maxPerColumn.ToList();
            }
            private static List<int> SimpleIterationWithLinq(List<string[]> input)
            {
                return input.Aggregate(new int[input.First().Length], (maxPerColumn, row) =>
                 {
                     for (int i = 0; i < row.Length; i++)
                         if (maxPerColumn[i] < row[i].Length)
                             maxPerColumn[i] = row[i].Length;
                     return maxPerColumn;
                 }).ToList();
            }
            private static List<int> AcceptedAnswer(List<string[]> input)
            {
                return Enumerable.Range(0, input.First().Length)
                                 .Select(i => input.Max(arr => arr[i].Length))
                                 .ToList();
            }
            private static List<int> TomDoesCode(List<string[]> input)
            {
                return input.First().Select((x, i) => input.Max(y => y[i].Length)).ToList();
            }
            private static List<int> Kobi(List<string[]> input)
            {
                return input.Select(strings => strings.Select(s => s.Length))
                          .Aggregate((prev, current) => prev.Zip(current, Math.Max)).ToList();
            }
            private static List<int> Konamiman(List<string[]> input)
            {
                var rowLength = input[0].Length;
                return Enumerable.Range(0, rowLength)
                    .Select(index => input.Select(row => row[index].Length).Max())
                    .ToList();
            }
            private static List<int> RahulSingh(List<string[]> input)
            {
                int arrayLength = input.First().Length;
                return input.SelectMany(x => x)
                                         .Select((v, i) => new { Value = v, Index = i % arrayLength })
                                         .GroupBy(x => x.Index)
                                         .Select(x => x.Max(z => z.Value.Length))
                                         .ToList();
            }
            private static List<int> Time(Func<List<string[]>, List<int>> act, List<string[]> input, string methodName)
            {
                Stopwatch s = Stopwatch.StartNew();
                var result = act(input);
                s.Stop();
                Console.WriteLine(methodName.PadRight(25) + ":" + s.ElapsedMilliseconds + " ms");
                return result;
            }
        }
    }
