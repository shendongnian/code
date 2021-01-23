    public override IEnumreable<Type> SupportedTypes
    {
       get
       {
          return new[]{typeof(Nullable<TimeSpan>)};
    }
    public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    {
       if (dictionary.Count == 0)
       {
          return null;
       }
       return new TimeSpanConverter().Deserialize(dictionary, type, serializer);
    }
