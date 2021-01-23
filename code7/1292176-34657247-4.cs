        private static void TestSimple()
        {
            var test = new HasByteArray { EncryptedPassword = Convert.FromBase64String("cGFzc3dvcmQ=") };
            try
            {
                TestRoundTrip(test);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        private static void TestRoundTrip<T>(T item)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
            };
            TestRoundTrip<T>(item, jsonSerializerSettings);
        }
        private static void TestRoundTrip<T>(T item, JsonSerializerSettings jsonSerializerSettings)
        {
            var json = JsonConvert.SerializeObject(item, Formatting.Indented, jsonSerializerSettings);
            Debug.WriteLine(json);
            var item2 = JsonConvert.DeserializeObject<T>(json, jsonSerializerSettings);
            var json2 = JsonConvert.SerializeObject(item2, Formatting.Indented, jsonSerializerSettings);
            Debug.WriteLine(json2);
            if (!JToken.DeepEquals(JToken.Parse(json), JToken.Parse(json2)))
                throw new InvalidOperationException("Round Trip Failed");
        }
