    var array2D = Get2DArray(); //some function to populate, you can have your own way to populate your 2D array
    
    List<int> columnSum = new List<int>();
    for (int j = 0; j < array2D.length ; ++j)
    {
        int sum = 0;
        for (int i = 0; i < array2D[j].length; ++i)
        {
            sum = sum + array2D[i][j];
        }
        
        columnSum.Add(sum); // columnSum List contain the sum of individual column
    }
