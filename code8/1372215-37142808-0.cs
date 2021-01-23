      public static partial class Array2DExtensions {
        public static IEnumerable<T> Vicinity<T>(this T[,] data, int line, int col) {
          if (null == data)
            throw new ArgumentNullException("data");
          //TODO: you may want to add range check here
    
          for (int i = Math.Max(data.GetLowerBound(0), line - 1); 
                   i <= Math.Min(data.GetUpperBound(0), line + 1); 
                   ++i)
            for (int j = Math.Max(data.GetLowerBound(1), col - 1); 
                     j <= Math.Min(data.GetUpperBound(1), col + 1); 
                     ++j)
              yield return data[i, j];
        }
      }  
