    int j;
    for (int i = 0; i < path.Count; i++)
    {
        PathTiles[] links = new PathTiles[2]; //<-- here
        if (i + 1 < path.Count)
        {
             links[0] = path[i];
             links[1] = path[i];
             ...
