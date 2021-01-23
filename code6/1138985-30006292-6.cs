    static void Main()
        {
            //variables
            int row = 0,
                column = 0,
                largestRandom = 0,
                maxX = 0,
                maxY = 0;
            //method calls
            row = GetRow(row);
            column = GetColumn(column);
            int[,] randomArray = new int[column, row];
            FillArray(row, column, randomArray);
            largestRandom = GetLargestNumber(ref randomArray, row, column, out maxX, out maxY);
            DisplayResults(randomArray, largestRandom, maxX, maxY);
            //determine whether user wants to run the program again
            Console.WriteLine("Do you want to create another array?");
            Console.WriteLine("Press 'Y if yes; 'N' if no");
            char userResponse;
            userResponse = Convert.ToChar(Console.ReadLine());
            if (userResponse == 'Y' || userResponse == 'y')
                Main();
        }
        //method to ask the user to enter the row size for the array
        static int GetRow(int row)
        {
            //variables
            string rawRow;
            Console.Write("Please enter the number of rows for your array: ");
            rawRow = Console.ReadLine();
            row = Convert.ToInt32(rawRow);
            return row;
        }
        //method to ask the user to enter the column size for the array    
        static int GetColumn(int column)
        {
            //variables
            string rawColumn;
            Console.WriteLine("\nPlease enter the number of columns for your array: ");
            rawColumn = Console.ReadLine();
            column = Convert.ToInt32(rawColumn);
            return column;
        }
        //method to fill the array with random numbers
        static int[,] FillArray(int row, int column, int[,] randomArray)
        {
            //creates a random variable to fill the array
            Random randFill = new Random();
            //loop to fill the array with random numbers
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    randomArray[i, j] = randFill.Next(0, 100);
                }
            }
            return randomArray;
        }
        /// <summary>
        /// Returns the largest number in the array.
        /// </summary>
        /// <param name="randomArray">The array to search.</param>
        /// <param name="rows">The amount of rows in the array.</param>
        /// <param name="columns">The amount of columns in the array.</param>
        /// <param name="maxX">The x-position (column) of the largest number in the array.</param>
        /// <param name="maxY">The y-position (row) of the largest number in the array.</param>
        /// <returns></returns>
        static int GetLargestNumber(ref int[,] randomArray, int rows, int columns, out int maxX, out int maxY)
        {
            int max = int.MinValue;
            maxX = -1;
            maxY = -1;
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (randomArray[x, y] > max)
                    {
                        max = randomArray[x, y];
                        maxX = x;
                        maxY = y;
                    }
                }
            }
            return max;
        }
        //method to display the results
        static void DisplayResults(int[,] randomArray, int largestRandom, int maxX, int maxY)
        {
            //display the array elements in a list
            for (int i = 0; i < randomArray.GetLength(0); i++)
                for (int j = 0; j < randomArray.GetLength(1); j++)
                    Console.WriteLine("{0,-3}", randomArray[i, j]);
            Console.WriteLine("\nLargest Number In Array: " + largestRandom);
            Console.WriteLine(String.Format("\nIndex Of Largest Number:\nX: {0}\nY: {1}\n ", maxX, maxY));
        }
