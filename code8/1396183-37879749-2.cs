      int[,] array = new int[,] {
        { 1, 2, },
        { 3, 4, },
        { 5, 6, },
      };
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < array.GetLength(0); ++i) {
        if (i > 0)
          sb.AppendLine();
        for (int j = 0; j < array.GetLength(1); ++j) { 
          if (j > 0)  
            sb.Append(" ");
          sb.Append(array[i, j]);
        }
      }
      String result = sb.ToString();
      // 1 2
      // 3 4
      // 5 6
      Console.Write(result);
      
