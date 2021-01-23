    double[,] d2 = { { 1, 2, 3 }, { 4, 5, 6 } };
    double[][] dj = d2.toJagged();
    Debug.Print(string.Join(", ", dj.SelectMany(i => i))); // 1, 2, 3, 4, 5, 6
                
    int[][] ij = new[] { new[] { 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8, 9 } };
    int[,] i2 = ij.to2D();
    Debug.Print(string.Join(", ", i2.Cast<int>())); // 1, 2, 0, 0, 3, 4, 5, 0, 6, 7, 8, 9
