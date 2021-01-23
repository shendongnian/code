    public static DataTable NestedTabulate(string json)
    {
        // Find the first array using Linq
        var jsonLinq = (JContainer)JToken.Parse(json);
        var srcArray = jsonLinq.DescendantsAndSelf().OfType<JArray>().First();
        RemoveEmptyArrayProperties(srcArray);
        ConvertObjectPropertiesToArrays(srcArray);
        return srcArray.ToObject<DataTable>();
    }
