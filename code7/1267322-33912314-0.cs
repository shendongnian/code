       List<int>[,] li = new List<int>[8,5];
    
       for (int r = 0; r < li.GetLength(0); ++r)
         for (int c = 0; c < li.GetLength(1); ++c)
           li[r, c] = new List<int>();
    
       li[0,0].Add(15);
