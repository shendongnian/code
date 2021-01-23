    public void MapData<T>(T genericData)
    {
        // do stuff with non-list data
    }
    public void MapData<T>(List<T> genericList)
    {
        MapListToField(genericList);
    }
