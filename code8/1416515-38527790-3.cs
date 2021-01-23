    public static DataTable FlattenTabulate(string json)
    {
        // Find the first array using Linq
        var jsonLinq = (JContainer)JToken.Parse(json);
        var srcArray = jsonLinq.DescendantsAndSelf().OfType<JArray>().First();
        RemoveEmptyArrayProperties(srcArray);
        FlattenObjectPropertiesToParents(srcArray);
        return srcArray.ToObject<DataTable>();
    }
