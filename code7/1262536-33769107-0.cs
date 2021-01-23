    public static T[][] ArrayClone<T>(T [][] array) 
    { 
         return System.Linq.Enumerable.ToArray(
             System.Linq.Enumerable.Select(array,
                 subArray => System.Linq.Enumerable.ToArray(subArray)));
    }
