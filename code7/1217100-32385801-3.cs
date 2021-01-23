    public static TileData[] ById = typeof(TileData)
                                    .GetFields(BindingFlags.Static | BindingFlags.Public)
                                    .Where(f => f.FieldType == typeof(TileData))
                                    .Select(f => f.GetValue(null))
                                    .Cast<TileData>()
                                    .OrderBy(td => td.Id)
                                    .ToArray();
    public static bool[] Walkable = ById.Select(td => td.IsWalkable).ToArray();
    // now you can have your map just be an array of array of ids
    // and say things like: if(TileData.Walkable[map[y][x]]) {etc.}
    
