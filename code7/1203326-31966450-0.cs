        public class rest_collection
        {
            public IEnumerable<rest_all_data> rest_all_datas { get; set; }
        }
        public void AddRestaurantMultiple([FromBody] JObject rest_all)
        {
            string k = rest_all.ToString();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            rest_collection collection = serializer.Deserialize<rest_collection>(k);
        }
