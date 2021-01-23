    using System;
    using System.Collections.Generic;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                List<int> matrix = MakeList(0,0,0,0,0,0,0,0,0);
                foreach(var element in Matrixify(3, matrix))
                    Console.WriteLine(ArrayToString(element));
            }
        
            // Used to make list easier...
            public static List<int> MakeList(params int[] elements)
            {
                return new List<int>(elements);
            }
        
            // Used for testing display.
            public static string ArrayToString(int[] arr)
            {
                return "[" + string.Join(",", arr) + "]";   
            }
        
            // Breaks a list into a matrix where delta is the # columns and # rows = len(list) / delta.
            public static int[][] Matrixify(int delta, List<int> list)
            {
                // Get a range of start index points.
                int[] arr = range(0, len(list), delta);
                // Used to make the matrix.
                List<int[]> result = new List<int[]>();
                // Chops up into rows.
                foreach(var i in arr)
                     result.Add(getRow(i, i + delta, list));
                // Sends back as an array of arrays (aka matrix).
                return result.ToArray();
            }
        
            // Grabs a row of the list passed in.
            public static int[] getRow(int start, int stop, List<int> list)
            {
                return list.GetRange(start, stop - start).ToArray();
            }
        
            // Works similar to python's len function.
            public static int len(List<int> list)
            {
                return list.Count;
            }
            public static int len(int[] list)
            {
                return list.Length;
            }
        
            // Works similar to python's range function.
            public static int[] range(int start, int stop, int step) 
            {
                int size = stop / step;
                int[] arr = new int[size];
                for(int i = 0; i < size; ++i)
                    arr[i] = start + (i * step);
                return arr;
            }
            public static int[] range(int start, int stop)
            {
                return range(start, stop, 1);
            }
        }
    }
