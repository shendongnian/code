    public override List<Animals> Deserialize(MongoDB.Bson.Serialization.BsonDeserializationContext context, MongoDB.Bson.Serialization.BsonDeserializationArgs args)
    {
        context.Reader.ReadStartArray();
		context.Reader.ReadBSonType();
        List<Animals> result = new List<Animals>();
        while (context.Reader.State != MongoDB.Bson.IO.BsonReaderState.EndOfArray)
        {
            context.Reader.ReadStartDocument();
            var type = context.Reader.ReadString();
            var _id = context.Reader.ReadObjectId();
            var name = context.Reader.ReadString();
            if (type == "Tiger")
            {
                double tiger_height = context.Reader.ReadDouble();
                result.Add(new Tiger()
                {
                    Id = id,
                    Name = animal_name,
                    Height = tiger_height
                });
            }
            else
            {
                long zebra_stripes = context.Reader.ReadInt64();
                result.Add(return new Zebra()
                {
                    Id = id,
                    Name = animal_name,
                    StripesAmount = zebra_stripes
                });
            }
            context.Reader.ReadEndDocument();
            context.Reader.ReadBsonType();
        }
		
        context.Reader.ReadEndArray();
		
        return result;
    }
