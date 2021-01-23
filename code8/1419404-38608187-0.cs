        public class url_details
        {
            public string url_short { get; set; }
            public string url_long { get; set; }
            public int type { get; set; }
        }
 
        public List<url_details> json_deserialized()
        {
            string json = "[{\"url_short\":\"http:\\/\\/sample.com\\/8jyKHv\",\"url_long\":\"http:\\/\\/www.sample.com\\/\",\"type\":0}]";
            List<url_details> items = new List<url_details>();
            items = JsonConvert.DeserializeObject<List<url_details>>(json);
            return items;
        }
     
