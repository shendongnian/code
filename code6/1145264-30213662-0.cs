    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
        {
            return null;
        }
        Node node = new Node();
        if (reader.TokenType == JsonToken.StartObject)
        {
            //initial call
            //here we have the object so we can use Populate
            JObject jObject = JObject.Load(reader);
            serializer.Populate(jObject.CreateReader(), node);
        }
        else
        {
            //the subsequent call
            //here we just have the int which is the ParentNode from the request
            //we can assign that to the Id here as this node will be set as the 
            //ParentNode on the original node from the first call
            node.Id = (int)(long)reader.Value;
        }
        return node;
    }
