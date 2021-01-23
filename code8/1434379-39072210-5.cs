    public static StringOrInt UpdateMapFetcher(int stationID, int typeID)
    {
        if (typeID == 0)
            return "Text";
        return 23;
    }
    private static void Main(string[] args)
    {
        var result = UpdateMapFetcher(1, 1);
        if (result.Type == ValueType.String) { }//can check before
        int integer = result;//compiles, valid
        string text = result;//compiles, fail at runtime, invalid cast      
    }
