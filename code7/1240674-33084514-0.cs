    class BigIntegerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Org.BouncyCastle.Math.BigInteger));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            System.Numerics.BigInteger big = (System.Numerics.BigInteger)reader.Value;
            return new Org.BouncyCastle.Math.BigInteger(big.ToString());
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }
