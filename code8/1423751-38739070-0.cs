    public List<Tile> FindDiamond(int tileX, int tileY, int radius)
    {
        List<Tile> ReturnList = new List<Tile>();
        for (int x = 0; x < radius; x++)
        {
            for (int y = 0; y < radius-x; y++)
            {
                ReturnList.Add(FindTile(tileX + x, tileY + y));
                ReturnList.Add(FindTile(tileX + x, tileY - y));
                ReturnList.Add(FindTile(tileX - x, tileY + y));
                ReturnList.Add(FindTile(tileX - x, tileY - y));
            }
        }
        return ReturnList;
    }
