    using System;
    
    class Program
    {
        static string[,] array = new string[,]
        {
            { "cat", "dog", "plane" },
            { "bird", "fish", "elephant" },
        };
        
        static int FindRow(string elem)
        {
            int rowCount = array.GetLength(0),
                colCount = array.GetLength(1);
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int colIndex = 0; colIndex < colCount; colIndex++)
                {
                    if (array[rowIndex, colIndex] == elem)
                    {
                        return rowIndex;
                    }
                }
            }
            return -1;
        }
        
        static string PickRandomTail(int rowIndex)
        {
            int colCount = array.GetLength(1);
            int randColIndex = new Random().Next(1, colCount);
            return array[rowIndex, randColIndex];
        }
        
        static void Main()
        {
            int rowIndex = FindRow("bird");
            if (rowIndex < 0)
            {
                // handle the element is not found
            }
            Console.WriteLine(PickRandomTail(rowIndex));
        }
    }
