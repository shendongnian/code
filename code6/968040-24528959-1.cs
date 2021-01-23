        [TestMethod]
        public void Test()
        {
            var json = "{\"status\":\"ok\",\"apirate\":\"0\",\"people\":{\n\"Mike\":{\"id\":\"Mike\",\"rating\":\"0.80\",\"questions\":\"100\"},\n\"Donald\":{\"id\":\"Donald\",\"rating\":\"0.7\",\"questions\":\"9\"},\n\"Tony\":{\"id\":\"Tony\",\"rating\":\"0.22\",\"questions\":\"2\"},\n\"Penelope\":{\"id\":\"Penelope\",\"rating\":\"0.006\",\"questions\":\"6\"},\n\"Sarah\":{\"id\":\"Sarah\",\"rating\":\"0.79\",\"questions\":\"20\"},\n\"Thomas\":{\"id\":\"Thomas\",\"rating\":\"0.12\",\"questions\":\"25\"},\n\"Gail\":{\"id\":\"Gail\",\"rating\":\"0.44\",\"questions\":\"35\"}}}";
            var folks = JsonConvert.DeserializeObject<Folks>(json);
            Assert.AreEqual("ok", folks.Status);
        }
        public class Folks
        {
            public Folks()
            {
                this.People = new Dictionary<string, PeopleDetails>();
            }
            [JsonProperty("status")]
            public string Status { get; set; }
            [JsonProperty("message")]
            public string Message { get; set; }
            [JsonProperty("apirate")]
            public int Apirate { get; set; }
            [JsonProperty("people")]
            public Dictionary<string, PeopleDetails> People { get; set; }
        }
        public class PeopleDetails
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            
            [JsonProperty("rating")]
            public decimal Rating { get; set; }
            
            [JsonProperty("questions")]
            public int Questions { get; set; }
        }
