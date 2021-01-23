    private TileData(bool walkable, bool buildSpace, Zone zone, int grahpicIndex){
        IsWalkable = walkable;
        IsBuildSpace = buildSpace;
        ZoneType = zone;
        TileGraphicIndex = grahpicIndex;
    }
    private static TileData Tweak(TileData parent, Action<TileData> tweaks) {
        var newTile = parent.MemberwiseClone();
        tweaks(newTile);
        return newTile;
    }
