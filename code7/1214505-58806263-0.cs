    public class HandleEnumsJsonSerializerStrategy : PocoJsonSerializerStrategy
    {
      public override object DeserializeObject(object value, Type type)
      {
        if (type.IsEnum)
          return Enum.Parse(type, (string)value);
        else
          return base.DeserializeObject(value, type);
      }
    }
