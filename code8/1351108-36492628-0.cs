     public void myCoolFunction()
     {
        int[,] theResults = new int [rowNum,colNum]{{4, 7, 4},       
                   {5, 1, 7},
                   {6, 5, 8}};  
         int[,] copyTheResult = (int[,]) theResult.Clone();
         int[] results = processResults(theResults);
            // Similary you can do for all arrays.
     }
