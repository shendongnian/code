    public static class ArrayHelper
    {
       public static object FindInDimensions(this object[,] target, 
       object searchTerm)
      {
        object result = null;
        var rowLowerLimit = target.GetLowerBound(0);
        var rowUpperLimit = target.GetUpperBound(0);
        var colLowerLimit = target.GetLowerBound(1);
        var colUpperLimit = target.GetUpperBound(1);
        for (int row = rowLowerLimit; row < rowUpperLimit; row++)
        {
            for (int col = colLowerLimit; col < colUpperLimit; col++)
            {
                // you could do the search here...
            }
        }
        return result;
    }
}
