    public class Supply
    {
        public string id { get; set; }
        public string deleted { get; set; }
        public string provider { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> items_id_num { get; set; }
        public string items_id_num_json
        {
            get
            {
                if (items_id_num == null)
                    return null;
                return JsonConvert.SerializeObject(items_id_num);
            }
            set
            {
                if (value == null)
                    items_id_num = null;
                else
                    items_id_num = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
            }
        }
        public string creator { get; set; }
        public string creation_time { get; set; }
    }
