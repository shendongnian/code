    public List<Vector2> Series1Data;
    //I populate the List with some coordinates
    float[] xCoordinates = new float[Series1Data.Count]
    for(int i = 0; i < Series1Data.Count; i++)
    {
        xCoordinates[i] = Series1Data[i].x;
    }
    MaXValue = Mathf.Max(xCoordinates);
