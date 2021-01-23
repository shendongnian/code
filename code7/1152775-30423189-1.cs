    public class MyListAnimalSerializer : SerializerBase<List<Animals>>
    {
    	public override void Serialize(MongoDB.Bson.Serialization.BsonSerializationContext context, MongoDB.Bson.Serialization.BsonSerializationArgs args, List<Animal> value)
    	{
    		context.Writer.WriteStartArray();
    		foreach (Animal mvnt in value)
    		{
    			context.Writer.WriteStartDocument();
    			switch (mvnt.GetType().Name)
    			{
    				case "Tiger":
    					//your serialization here
    					break;
    				case "Zebra":
    					//your serialization here
    					break;
    				default:
    					break;
    			}
    			context.Writer.WriteEndDocument();
    		}
    		context.Writer.WriteEndArray();
    	}
    
    	public override List<Animals> Deserialize(MongoDB.Bson.Serialization.BsonDeserializationContext context, MongoDB.Bson.Serialization.BsonDeserializationArgs args)
    	{
    		context.Reader.ReadStartArray();
    
    		List<Animals> result = new List<Animals>();
    
    		while (true)
    		{
    			try
    			{
    				//this catch block only need to identify the end of the Array
    				context.Reader.ReadStartDocument();
    			}
    			catch (Exception exp)
    			{
    				context.Reader.ReadEndArray();
    				break;
    			}
    
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
    		}
    		return result;
    	}
    }
