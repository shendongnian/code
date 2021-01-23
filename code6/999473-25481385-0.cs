    public class Api
    {
        public string api_ver { get; set; }
        public string request { get; set; }
        public string date { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public int user_account_exists { get; set; }
    }
