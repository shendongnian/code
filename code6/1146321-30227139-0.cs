    ForEachPair(5, 5, (x, y) =>
    {
        Console.Write(x + "," + y);
    });
    public void ForEachPair(int width, int height, Action<int, int> callback)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                callback(i, j);
            }
        }
    }
