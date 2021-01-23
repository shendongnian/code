    internal static JToken FromObjectInternal(object o, JsonSerializer jsonSerializer)
    {
         ValidationUtils.ArgumentNotNull(o, "o");
         ValidationUtils.ArgumentNotNull(jsonSerializer, "jsonSerializer");
         JToken token;
         using (JTokenWriter jsonWriter = new JTokenWriter())
         {
             jsonSerializer.Serialize(jsonWriter, o);
             token = jsonWriter.Token;
         }
         return token;
    }
