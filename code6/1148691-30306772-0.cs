            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                MyTestXML myTestXml = (MyTestXML) value;
                JObject jObject = JObject.FromObject(value);
                JProperty prop = jObject.Children<JProperty>().First(p=>p.Name.Contains("MyObject"));
                if (myTestXml.MyObject.GetType() == typeof (MyFirstObject))
                {
                    prop.AddAfterSelf(new JProperty("First", JToken.FromObject(myTestXml.MyObject)));
                    prop.Remove();
                    jObject.WriteTo(writer);
                }
                else if (myTestXml.MyObject.GetType() == typeof (MySecondObject))
                {
                    prop.AddAfterSelf(new JProperty("Second", JToken.FromObject(myTestXml.MyObject)));
                    prop.Remove();
                    jObject.WriteTo(writer);                    
                }
            }
