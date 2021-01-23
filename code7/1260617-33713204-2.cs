    using System;
    using System.Collections.Generic;
    namespace Rextester
    {
        public class Program
        {
            public class INT
            {
                private int _i;
                public INT()      { _i = 0; }
                public INT(int i) { _i = i; }
                // Used to access the _i member.
                public int self
                {
                    get {return _i;}
                    set {_i = value;}
                }
                // Used to display what is stored inside.
                public override string ToString()
                {
                    return _i + "";
                }
            }
        
            public static void Main(string[] args)
            {
                List<INT> matrix = MakeList(9);
                foreach(var element in Matrixify(3, matrix))
                    Console.WriteLine(ArrayToString(element));
            }
        
            // Used to make list easier...
            public static List<INT> MakeList(int count)
            {
                List<INT> list = new List<INT>();
                for(int i = 0; i < count; ++i)
                    list.Add(new INT());
                return list;
            }
        
            // Used for testing display.
            public static string ArrayToString(INT[] arr)
            {
                return "[" + string.Join<INT>(",", arr) + "]";
            }
        
            // Breaks a list into a matrix where delta is the # columns and # rows = len(list) / delta.
            public static INT[][] Matrixify(int delta, List<INT> list)
            {
                // Get a range of start index points.
                int[] arr = range(0, len(list), delta);
                // Used to make the matrix.
                List<INT[]> result = new List<INT[]>();
                // Chops up into rows.
                foreach(var i in arr)
                     result.Add(getRow(i, i + delta, list));
                // Sends back as an array of arrays (aka matrix).
                return result.ToArray();
            }
        
            // Grabs a row of the list passed in.
            public static INT[] getRow(int start, int stop, List<INT> list)
            {
                return list.GetRange(start, stop - start).ToArray();
            }
        
            // Works similar to python's len function.
            public static int len(List<INT> list)
            {
                return list.Count;
            }
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
