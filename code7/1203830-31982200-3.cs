    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2
    {
        internal class Program
        {
            static byte[] ConvertWithBuffer(List<string> list)
            {
                int totalSize = list.Sum(x => Encoding.UTF8.GetByteCount(x));
                byte[] buffer = new byte[totalSize];
                int ix = 0;
                foreach (string str in list)
                    ix += Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, ix);
                return buffer;
            }
            static byte[] ConvertWithConcat(List<string> list) { return Encoding.UTF8.GetBytes(String.Concat(list)); }
            static byte[] ConvertWithSelectMany(List<string> list)
            {
                return list
                    .SelectMany(line => Encoding.UTF8.GetBytes(line))
                    .ToArray();
            }
            static byte[] ConvertWithString(List<string> input)
            {
                string fullString = String.Join(String.Empty, input.ToArray());
                return Encoding.UTF8.GetBytes(fullString);
            }
            static byte[] ConvertWithStringBuilder(List<string> input)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in input)
                    sb.Append(s);
                return Encoding.UTF8.GetBytes(sb.ToString());
            }
            static IEnumerable<string> CreateList()
            {
                for (int i = 0; i < 10000000; i++)
                    yield return i.ToString();
            }
            static void Main(string[] args)
            {
                List<string> strings = CreateList().ToList();
                Stopwatch stopWatch = Stopwatch.StartNew();
                // warm up
                ConvertWithString(strings);
                ConvertWithStringBuilder(strings);
                ConvertWithConcat(strings);
                ConvertWithSelectMany(strings);
                ConvertWithBuffer(strings);
                // testing
                stopWatch.Restart();
                ConvertWithString(strings);
                Console.WriteLine("ConvertWithString {0}ms", stopWatch.ElapsedMilliseconds);
                stopWatch.Restart();
                ConvertWithStringBuilder(strings);
                Console.WriteLine("ConvertWithStringBuilder {0}ms", stopWatch.ElapsedMilliseconds);
                stopWatch.Restart();
                ConvertWithConcat(strings);
                Console.WriteLine("ConvertWithConcat {0}ms", stopWatch.ElapsedMilliseconds);
                stopWatch.Restart();
                ConvertWithSelectMany(strings);
                Console.WriteLine("ConvertWithSelectMany {0}ms", stopWatch.ElapsedMilliseconds);
                stopWatch.Restart();
                ConvertWithBuffer(strings);
                Console.WriteLine("ConvertWithBuffer {0}ms", stopWatch.ElapsedMilliseconds);
                Console.WriteLine("press any key...");
                Console.ReadKey();
            }
        }
    }
