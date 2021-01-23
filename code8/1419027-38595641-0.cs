    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string jsonStr = @"{""obj"": 7, ""arr"": ['1','2','3']}";
                Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonStr, new SpecialConverter<string, long>());
    
                dict["obj"].GetType(); // long
                dict["arr"].GetType(); // string[].
            }
    
            class SpecialConverter<T1, T2> : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return true;
                }
    
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    JToken token = JToken.Load(reader);
                    var result = new Dictionary<string, object>();
                    if (result.GetType() == objectType)
                    {
                        foreach (var item in token)
                        {
                            var prop = (JProperty)item;
                            if (prop.Value.Type == JTokenType.Array)
                            {
                                result.Add(prop.Name, prop.Value.ToObject<T1[]>());
                            }
                            else
                            {
                                result.Add(prop.Name, prop.Value.ToObject<T2>());
                            }
                        }
    
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
    
                public override bool CanWrite
                {
                    get { return false; }
                }
    
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
