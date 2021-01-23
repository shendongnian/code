            var settings = new JsonSerializerSettings { DateParseHandling = DateParseHandling.None };
            var data = JsonConvert.DeserializeObject<JObject>(@"{
                ""SimpleDate"":""2012-05-18T00:00:00Z"",
                ""PatternDate"":""2012-11-07T00:00:00Z""
            }", settings);
            var value = data["SimpleDate"].Value<string>();
            Debug.WriteLine(value); // Outputs 2012-05-18T00:00:00Z
