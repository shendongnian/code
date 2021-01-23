    public int countNonZero(int[][] myList, int row)
    {
       var res = 0;
       for (int i = 0; i < numColumns; ++i)
         if (myList[row][i] != 0) ++res;
       return res;
    }
    
    public void removeConflicts(int[][] myList)
    {
       for (int i = 0; i < numRows; ++i)
       {
          var iNum = countNonZero(myList, i);
          for (int j = i + 1; j < numRows; ++j)
          {
             var jNum = countNonZero(myList, j);
             if (iNum == jNum)
             {
                 // row #i conflicts with row #j
             }
          }
       }
    }
