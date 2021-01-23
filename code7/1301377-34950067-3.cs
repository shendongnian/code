        public class ObjectAsArrayConverter : JsonConverter 
        {
          public override bool CanConvert(Type type)
          {			
            return
              type.IsGenericType &&
              typeof(List<>) == type.GetGenericTypeDefinition() &&
              typeof(Data) == type.GetGenericArguments()[0];
          }
          
          public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
          {
            JObject obj = JObject.ReadFrom(reader).ToObject<JObject>();
            
            return obj.Properties()
              .Select(p => new { Index = int.Parse(p.Name), Value = obj[p.Name].ToObject<Data>() })
              .OrderBy(p => p.Index)
              .Select(p => p.Value)
              .ToList();
          }
          
          public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
          {
            throw new NotImplementedException();
          }
          
        }
    This would allow you to deserialize your JSON into this structure:
        class Root 
        { 
            public List<Data> Data {get; set;}
        }
        class Data
        {
            public Test Test { get; set; }
        }
        class Test
        { 
            public string Col1 {get; set;} 
            public string Col2 {get; set;}
        }
    **Example:** https://dotnetfiddle.net/e2Df7h
