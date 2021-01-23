      object[,] paraArray = new object[,] {
        {1, 2, 3 },
        {4, 5, 6 },
      };
      ...
      string[,] arr = new string[paraArray.GetLength(0), paraArray.GetLength(1)];
      for (int i = 0; i < arr.GetLength(0); ++i)
        for (int j = 0; j < arr.GetLength(1); ++j)
          arr[i, j] = paraArray[i, j].ToString();
