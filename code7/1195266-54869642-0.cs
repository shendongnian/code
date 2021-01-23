       public class CustomEnumSerializer<TEnum>: MongoDB.Bson.Serialization.Serializers.EnumSerializer<TEnum>
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            public override TEnum Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
            {
                var bsonReader = context.Reader;
                var bsonType = bsonReader.GetCurrentBsonType();
                var val = "";
                switch (bsonType)
                {
                    case BsonType.String:
                        val = bsonReader.ReadString() ?? "";
                        break;
                    case BsonType.Int32:
                        val = bsonReader.ReadInt32().ToString();
                        break;
                    case BsonType.Int64:
                        val = bsonReader.ReadInt64().ToString();
                        break;
                    case BsonType.Null:
                        return default(TEnum);
                    default:
                        return base.Deserialize(context, args);
                }
                if(Enum.TryParse(val, true, out TEnum result)){
                    return result;
                }
                return default(TEnum);
            }
        }
