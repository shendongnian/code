        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            MyCommonObject result;
            if (IsFormatOne(jObject))
            {
                result = (existingValue as MyCommonObject ?? (MyCommonObject)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator()); // Reuse existingValue if present
                // the structure of the object matches the first format,
                // so just deserialize it directly using the serializer
                using (var subReader = jObject.CreateReader())
                    serializer.Populate(subReader, result);
            }
            else if (IsFormatTwo(jObject))
            {
                result = (existingValue as MyCommonObject ?? (MyCommonObject)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
                // initialize values from the JObject
                // ... 
            }
            else
            {
                throw new InvalidOperationException("Unknown format, cannot deserialize");
            }
            return result;
        }
