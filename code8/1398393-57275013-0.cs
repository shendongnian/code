    private void InitPaths()
    {
        PathDictionary.Clear();
        for (var rowstart = 0; rowstart < GridRowSize; rowstart++)
        {
            for (var colstart = 0; colstart < GridColSize; colstart++)
            {
                var tuples = new List<Tuple<int, int>>();
                for (var r = rowstart - 1; r <= rowstart + 1; r++)
                {
                    if (r < 0 || r >= GridRowSize) continue;
                    for (var c = colstart - 1; c <= colstart + 1; c++)
                    {
                        if (c < 0 || c >= GridColSize || (r == rowstart && c == colstart)) continue;
                        tuples.Add(new Tuple<int, int>(r, c));
                    }
                }
                PathDictionary.Add(new Tuple<int, int>(rowstart, colstart), tuples);
            }
        }
    }
