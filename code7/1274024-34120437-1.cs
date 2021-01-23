    public static void Main()
    {
        int rows = GetNumber("Enter no of Rows:");
        int columns = GetNumber("Enter no of Columns:");
        int[][] matrix = new int[rows][columns];
        for(int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                matrix[row][column] = GetNumber("Enter value for sector Row: "+(row+1)+" Column: "+(column+1));
            }
        }
        int smallestnumber = matrix[0][0];
        for(int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if(matrix[row][column] < smallestnumber)
                {
                    smallestnumber = matrix[row][column];
                }
            }
        }
        Console.WriteLine("Lowest number is: "+smallestnumber);
    }
