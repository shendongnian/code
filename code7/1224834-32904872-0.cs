    //example classes
    public class DictKey
    {
        public string DisplayName { get; set; }
        public DictKey(string name) { DisplayName = name; }
    }
    public class DictValue
    {
        public int ColumnIndex { get; set; }
        public DictValue(int idx) { ColumnIndex = idx; }
    }
    //utility method
    public static IDictionary<string, object> GetExpando(KeyValuePair<DictKey, List<DictValue>> dictPair)
    {
        IDictionary<string, object> dynamicObject = new ExpandoObject();
        dynamicObject["Station"] = dictPair.Key.DisplayName;
        foreach (var item in dictPair.Value)
        {
            dynamicObject["Month" + (item.ColumnIndex + 1)] = item;
        }
        return dynamicObject;
    }
