    For instance, when deserializing a `DataTable`, Json.NET's built-in [`DataTableConverter`](https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Converters/DataTableConverter.cs) will create columns in the order that they are encountered in the JSON file.
    It's also possible to write converters that assume a certain property order and thus are subtly broken.  For instance, consider the following:
        public struct Vector2D
        {
            public readonly double X;
            public readonly double Y;
            public Vector2D(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public class Vector2DConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Vector2D);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType != JsonToken.StartObject)
                    throw new JsonSerializationException();
                reader.Read(); // StartObject
                reader.Read(); // X
                var x = serializer.Deserialize<double>(reader);
                reader.Read(); // Consume value
                reader.Read(); // Y
                var y = serializer.Deserialize<double>(reader);
                reader.Read(); // Consume value
                reader.Read(); // EndObject
                return new Vector2D(x, y);
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                var vec = (Vector2D)value;
                writer.WriteStartObject();
                writer.WritePropertyName("X");
                writer.WriteValue(vec.X);
                writer.WritePropertyName("Y");
                writer.WriteValue(vec.Y);
                writer.WriteEndObject();
            }
        }
    The `Vector2DConverter` assumes that the properties `X` and `Y` come in a certain order, rather than checking the property names and deserializing accordingly.  While the converter can read what it writes, its order sensitivity fails to fully conform to the JSON standard.  
    None of Json.NET's [built-in converters](https://github.com/JamesNK/Newtonsoft.Json/tree/master/Src/Newtonsoft.Json/Converters) should be broken in this manner, but third-party converters might possibly be.
