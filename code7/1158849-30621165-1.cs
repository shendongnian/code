            //Json String
            var json = "{\"Value\":\"0.6\",\"Data\":{\"Data1\":0.1,\"Data2\":0.3,\"Data3\":0.3}}";
            //If you want to deserialize
            var objDeserialized = JsonConvert.DeserializeObject<Obj1>(json);
            //If you want to Serialize
            var objToSerialize = new Obj1()
            { 
                Value = "0.6",
                Data = new Dictionary<string, double>()
                {
                    {"Data1",0.1 },
                    {"Data2",0.3},
                    {"Data3",0.3 }
                }
            };
            var serializedObj = JsonConvert.SerializeObject(objToSerialize);
