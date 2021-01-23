    public class FooConverter : JsonConverter
    {      
       public FooConveter(params Type[] parameterTypes)
       {
           
       }
       public override bool CanConvert(Type objectType)
       {
          return objectType.IsAssignableFrom(typeof(FooA));
       }
       public override object ReadJson(JsonReader reader, Type objectType)
       {
          //Put your code to deserialize FooA here.  
          //You probably don't need it based on the scope of your question.
       }
       public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
       {
          //Code to serialize FooA.
          if (value == null)
          {
             writer.WriteNull();
             return;
          }
          //Only serialize SomeValueA
          var foo = value as FooA;
          writer.WriteStartObject();
          writer.WritePropertyName("FooA");
          writer.Serialize(writer, foo.SomeValueA);
          writer.WriteEndObject();          
       }
    }
