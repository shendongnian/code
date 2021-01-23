    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        public class Program
        {
            List<int[]> intArrList = new List<int[]>
            {
                new int[] { 0, 0, 0 },
                new int[] { 20, 30, 10, 4, 6 },  //this
                new int[] { 1, 2, 5 },
                new int[] { 20, 30, 10, 4, 6 },  //this
                new int[] { 12, 22, 54 },
                new int[] { 1, 2, 6, 7, 8 },
                new int[] { 0, 0, 0, 0 }
            };
    
            [Benchmark]
            public List<int[]> SAkbari_FindDistinctWithoutLinq() => FindDistinctWithoutLinq(intArrList);
    
            [Benchmark]
            public List<int[]> SAkbari_FindDistinctWithoutLinq2() => FindDistinctWithoutLinq2(intArrList);
    
            [Benchmark]
            public List<int[]> SAkbari_FindDistinctLinq() => FindDistinctLinq(intArrList);
    
            [Benchmark]
            public List<int[]> Mick_UsingGetHashCode() => FindDistinctLinq(intArrList);
    
            static void Main(string[] args)
            {
                var summary = BenchmarkRunner.Run<Program>();
            }
    
            public static List<int[]> FindDistinctWithoutLinq(List<int[]> lst)
            {
                var dic = new Dictionary<string, int[]>();
                foreach (var item in lst)
                {
                    string key = string.Join(",", item.OrderBy(c => c));
    
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, item);
                    }
                }
    
                return dic.Values.ToList();
            }
    
            public static List<int[]> FindDistinctWithoutLinq2(List<int[]> lst)
            {
                var dic = new Dictionary<string, int[]>();
    
                foreach (var item in lst)
                    dic.TryAdd(string.Join(",", item.OrderBy(c => c)), item);
    
                return dic.Values.ToList();
            }
    
            public static List<int[]> FindDistinctLinq(List<int[]> lst)
            {
                return lst.GroupBy(p => string.Join(", ", p.OrderBy(c => c)))
                           .Select(c => c.First().ToArray()).ToList();
            }
    
            public static List<int[]> UsingGetHashCode(List<int[]> lst)
            {
                return lst.Select(a => a.OrderBy(e => e).ToArray()).Distinct(new IntArrayEqualityComparer()).ToList();
            }
        }
    
        public class IntArrayEqualityComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
            {
                return ArraysEqual(x, y);
            }
    
            public int GetHashCode(int[] obj)
            {
                int hc = obj.Length;
                for (int i = 0; i < obj.Length; ++i)
                {
                    hc = unchecked(hc * 17 + obj[i]);
                }
                return hc;
            }
    
            static bool ArraysEqual<T>(T[] a1, T[] a2)
            {
                if (ReferenceEquals(a1, a2))
                    return true;
    
                if (a1 == null || a2 == null)
                    return false;
    
                if (a1.Length != a2.Length)
                    return false;
    
                EqualityComparer<T> comparer = EqualityComparer<T>.Default;
                for (int i = 0; i < a1.Length; i++)
                {
                    if (!comparer.Equals(a1[i], a2[i])) return false;
                }
                return true;
            }
        }
    }
