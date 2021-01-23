    internal class MesureSerializer : IBsonSerializer
    {
      private readonly IBsonSerializer _classMapSerializer;
      public MesureSerializer()
      {
         var classMap = BsonClassMap.LookupClassMap(typeof(MyClassA));
         _classMapSerializer = new BsonClassMapSerializer(classMap);
      }
      object IBsonSerializer.Deserialize(MongoDB.Bson.IO.BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
      {
         return _classMapSerializer.Deserialize(bsonReader, nominalType, actualType, options);
      }
      
      void IBsonSerializer.Serialize(MongoDB.Bson.IO.BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
      {
         MyClassA item = (MyClassA)value;
         if(item.myClassD != null)
         {
            using(MemoryStream stream = new MemoryStream())
            {
               item.myClassD.Save(item.myClassD, stream);
               mesure.myClassDBin = stream.ToArray();
            }
         }
         else
         {
            item.myClassDBin = null;
         }
         _classMapSerializer.Serialize(bsonWriter, nominalType, item, options);
         item.myClassDBin = null;
      }
      object IBsonSerializer.Deserialize(MongoDB.Bson.IO.BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
      {
         return _classMapSerializer.Deserialize(bsonReader, nominalType, options);
      }
      IBsonSerializationOptions IBsonSerializer.GetDefaultSerializationOptions()
      {
         return _classMapSerializer.GetDefaultSerializationOptions();
      }
    }
