                var o = new Test { MyProperty = Encoding.UTF8 };
                var s = new JsonSerializerSettings
                {
                    Converters = new[] { new CustomConverter() }
                };
                var v = JsonConvert.SerializeObject(o, s);
                var o2 = new Test();
                o2.MyProperty = Encoding.GetEncoding(JsonConvert.DeserializeObject(v, s).ToString());
