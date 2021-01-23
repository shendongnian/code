    public class Rootobject
    {
        public int status_code { get; set; }
        public string status_txt { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public string long_url { get; set; }
        public string url { get; set; }
        public string hash { get; set; }
        public string global_hash { get; set; }
        public int new_hash { get; set; }
    }
