    public class PropertyDictionary : Dictionary<string, ICustomProperty>
    {
      public PropertyDictionary(Dictionary<string, ICustomProperty> dict)
        : base(dict)
      {}
    }
