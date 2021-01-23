    public class Settings
    {
        [JsonProperty]
        public static int IntSetting { get; set; }
        [JsonProperty]
        public static string StrSetting { get; set; }
        static Settings()
        {
            IntSetting = 5;
            StrSetting = "Test str";
        }
    }
