    [JsonConverter(typeof(ComplexDictionaryConverter<Employee, double>))]
    public class ChildDictionary : Dictionary<Employee, double>
    {
        ...
    }
