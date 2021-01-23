    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        public class Program
        {
            private static void Main()
            {
                var sw = new Stopwatch();
                int n = 1024*1024*16;
                int count = 10;
                int dummy = 0;
                for (int trial = 0; trial < 4; ++trial)
                {
                    sw.Restart();
                    for (int i = 0; i < count; ++i)
                        dummy += method1(n).Count;
                    Console.WriteLine("Enumerable.Repeat() took " + sw.Elapsed);
                    sw.Restart();
                    for (int i = 0; i < count; ++i)
                        dummy += method2(n).Count;
                    Console.WriteLine("list.Add() took " + sw.Elapsed);
                    sw.Restart();
                    for (int i = 0; i < count; ++i)
                        dummy += method3(n).Count;
                    Console.WriteLine("(new float[n]) took " + sw.Elapsed);
                    Console.WriteLine("\n");
                }
            }
            private static List<float> method1(int n)
            {
                var list = new List<float>(n);
                list.AddRange(Enumerable.Repeat(0f, n));
                return list;
            }
            private static List<float> method2(int n)
            {
                var list = new List<float>(n);
                for (int i = 0; i < n; ++i)
                    list.Add(0f);
                return list;
            }
            private static List<float> method3(int n)
            {
                return new List<float>(new float[n]);
            }
        }
    }
