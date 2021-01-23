    static int max_connected_region(int x0, int y0, int[,] mat)
    {
        if (mat[x0, y0] == 0)
            return 0;
        var surroundings = (new int[][] {
            new int[] { x0 - 1, y0 }, new int[] {x0 + 1, y0 }, 
            new int[] { x0 - 1, y0 + 1}, new int[] { x0, y0 + 1 }, new int[] {x0 + 1, y0 + 1},
            new int[] { x0 - 1, y0 - 1}, new int[] { x0, y0 - 1 }, new int[] {x0 + 1, y0 - 1} }
         ).Where(pair => pair[0] >= 0 && pair[0] < mat.GetLength(0) && pair[1] >= 0 && pair[1] < mat.GetLength(1));
        int count = 1;
        mat[x0, y0] = 0;
        foreach (var pair in surroundings)
            count += max_connected_region(pair[0], pair[1], mat);
        return count;
    }
