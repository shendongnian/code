        public T ReadTypeAndDiscardTheRest<T>(string json)
        {
            using (var sr = new StringReader(json))
            using (var jsonReader = new JsonTextReader(sr))
            {
                var token = JToken.Load(jsonReader);
                return token.ToObject<T>();
            }
        }
        [Test]
        public void TestJsonDiscarding()
        {
            var json = @"{""Key"":""a"", ""Value"":""n""}<?xml>aaaa";
            var kp = ReadTypeAndDiscardTheRest<KeyValuePair<string, string>>(json);
            Assert.That(kp.Key, Is.EqualTo("a"));
            Assert.That(kp.Value, Is.EqualTo("n"));
        }
