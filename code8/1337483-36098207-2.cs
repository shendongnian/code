    IEnumerable<List<Point>> GetPathSet(Point X, Point Y, params List<Point>[] layers)
    {
        int[] layerindexes = new int[layers.Length];
        while (true)
        {
            var Path = new List<Point>();
            Path.Add(X);
            for (int i = 0; i < layers.Length; i++)
                Path.Add(layers[i][layerindexes[i]]);
            Path.Add(Y);
            for (int i = layers.Length - 1; i >= 0; i--)
            {
                layerindexes[i]++;
                if (layerindexes[i] >= layers[i].Count)
                {
                    layerindexes[i] = 0;
                    if (i == 0) yield break;
                }
                else break;
            }
            yield return Path;
        }
    }
