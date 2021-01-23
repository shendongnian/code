    using System;
    
    class Program
    {
        static string[,] array = new string[,]
        {
            { "cat", "dog", "plane" },
            { "bird", "fish", "elephant" },
        };
        
        static void FindElement(string elem, out int rowIndex, out int colIndex)
        {
            int rowCount = array.GetLength(0),
                colCount = array.GetLength(1);
            for (rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (colIndex = 0; colIndex < colCount; colIndex++)
                {
                    if (array[rowIndex, colIndex] == elem)
                    {
                        return;
                    }
                }
            }
            rowIndex = -1;
            colIndex = -1;
        }
        
        static string PickRandomTail(int rowIndex, int colIndex)
        {
            int colCount = array.GetLength(1);
            int randColIndex = new Random().Next(rowIndex+1, colCount);
            return array[rowIndex, randColIndex];
        }
        
        static void Main()
        {
            int rowIndex, colIndex;
            FindElement("bird", out rowIndex, out colIndex);
            if (rowIndex < 0 || colIndex < 0) {
                // handle the element is not found
            }
            if (colIndex + 1 >= array.GetLength(1)) {
                // handle that the element was last of its column. It's not possible
                // to pick any elements after that.
            }
            Console.WriteLine(PickRandomTail(rowIndex, colIndex));
        }
    }
