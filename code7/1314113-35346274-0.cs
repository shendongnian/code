    public static void arrayAverage(int[,] array)
        {
            int total = 0;
            //Get number of rows 
            int rows = Math.Min(array.GetLength(0),array.GetLength(1));
            
            //Iterate through diagonal elements
            for (int i= 0; i < rows; i++)
            {
                total += array[i, i];
            }
            //Multiple 1.0 to prevent data lost.
            double average = 1.0*total / rows;
            Console.WriteLine("Total: " + average);
        }
