    // In order to convert any 2d array to jagged one
    // let's use a generic implementation
    public static T[][] ToJagged<T>(T[,] value) {
      if (Object.ReferenceEquals(null, value))
        return null;
    
      // Jagged array creation
      T[][] result = new T[value.GetLength(0)][];
    
      for (int i = 0; i < value.GetLength(0); ++i) 
        result[i] = new T[value.GetLength(1)];
    
      // Jagged array filling
      for (int i = 0; i < value.GetLength(0); ++i)
        for (int j = 0; j < value.GetLength(1); ++j)
          result[i][j] = value[i, j];
    
      return result;
    }
