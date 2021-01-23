    int[,] dummyArray = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
    int count = 0;
    List<int[]> list = dummyArray.Cast<int>()
                        .GroupBy(x => count++ / dummyArray.GetLength(1))
                        .Select(g => g.ToArray())
                        .ToList();
