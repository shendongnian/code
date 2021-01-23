            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                MyTestXML myTestXml = new MyTestXML();
                serializer.Populate(jo.CreateReader(), myTestXml);
                object myObject = null;
                if (jo["First"] != null)
                {
                    myObject = new MyFirstObject { TheFirstObjectString = jo["First"].SelectToken(@"TheFirstObjectString").Value<string>() };
                }
                if (jo["Second"] != null)
                {
                    myObject = new MySecondObject { TheSecondObjectString = jo["Second"].SelectToken(@"TheSecondObjectString").Value<string>() };
                }
                myTestXml.MyObject = myObject;
                return myTestXml;
            }
