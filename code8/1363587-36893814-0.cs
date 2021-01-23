    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication88
    {
        class Program
        {
            static void Main(string[] args)
            {
                EnumerateArray eArray = new EnumerateArray() {
                    new List<int>() {1,2,3,4},
                    new List<int>() {5,6,7,8},
                    new List<int>() {9,10,11,12},
                    new List<int>() {13,14,15,16},
                    new List<int>() {17,18,19,20}
                };
                foreach (List<int> x in eArray)
                {
                    Console.WriteLine(string.Join(",", x.Select(y => y.ToString()).ToArray()));
                }
                Console.ReadLine();
     
            }
        }
       
        public class EnumerateArray : IEnumerator, IEnumerable
        {
            public List<List<int>> myArray { get; set;}
            int row = 0;
            int col = 0;
            int numCols = 0;
            int numRows = 0;
            public int Count { get; set; }
            public int[] current = null;
            Boolean finishedCol = false;
            public EnumerateArray()
            {
                myArray = new List<List<int>>();
            }
            public EnumerateArray(List<List<int>> array)
            {
                myArray = array;
                Reset();
                numRows = array.Count;
                numCols = array[0].Count;
                Count = numCols + numRows;
            }
            public void Add(List<int> array)
            {
                myArray.Add(array);
                numRows = myArray.Count;
                numCols = array.Count;
                Count = numCols + numRows;
            }
            public void Add(List<List<int>> array)
            {
                myArray = array;
                Reset();
                numRows = array.Count;
                numCols = array[0].Count;
                Count = numCols + numRows;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }
            public EnumerateArray GetEnumerator()
            {
                return new EnumerateArray(myArray);
            }
            public bool MoveNext()
            {
                Boolean done = true;
                if (finishedCol == false)
                {
                    if (col < numCols - 1)
                    {
                        col++;
                    }
                    else
                    {
                        finishedCol = true;
                        row = 0;
                    }
                }
                else
                {
                    if (row < numRows - 1)
                    {
                        row++;
                    }
                    else
                    {
                        done = false;
                    }
                }
                
                return done;
            }
            public void Reset()
            {
                row = -1;
                col = -1;
                finishedCol = false;
                Count = numCols + numRows;
            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }
            public List<int> Current
            {
                get
                {
                    try
                    {
                        List<int> _array = new List<int>();
                        if (finishedCol == false)
                        {
                            
                            for (int _row = 0; _row < numRows; _row++)
                            {
                                _array.Add(myArray[_row][ col]);
                            }
                        }
                        else
                        {
                            _array.AddRange(myArray[row]);
                        }
                        return _array;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
        
    }
