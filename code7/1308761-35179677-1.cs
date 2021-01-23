    public class ArrayItemConverter : JsonConverter
    {
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
        throw new NotImplementedException();
      }
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
        object retVal = (string)null;
        if (reader.TokenType == JsonToken.StartObject)
        {
          Item instance = (Item)serializer.Deserialize<Item>(reader);
          retVal = new List<Item>() { instance };
        }
        else if (reader.TokenType == JsonToken.StartArray)
        {
          List<Item> list = serializer.Deserialize<List<Item>>(reader);
          retVal = list;
        }
        return retVal;
      }
      public override bool CanConvert(Type objectType)
      {
        return true;
      }
    }
