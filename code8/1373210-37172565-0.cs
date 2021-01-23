        public T ReadTypeAndDiscardTheRest<T>(string json)
        {
            using (var sr = new StringReader(json))
            using (var jsonReader = new JsonTextReader(sr))
            {
                var token = JToken.Load(jsonReader);
                return token.ToObject<T>();
            }
        }
