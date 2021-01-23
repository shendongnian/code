        namespace SourceMonitor
        {
            public class Settings
            {
                public class Webserver
                {
                    [JsonProperty("hostname")]
                    public string hostname { get; set; }
                    [JsonProperty("port")]
                    public string port { get; set; }
                }
                public class Gameserver
                {
                    [JsonProperty("hostname")]
                    public string hostname { get; set; }
                    [JsonProperty("port")]
                    public string port { get; set; }
                    [JsonProperty("password")]
                    public string password { get; set; }
                }
                [JsonProperty("webserver")]
                public Webserver webserver { get; set; }
                [JsonProperty("gameserver")]
                public Gameserver gameserver { get; set; }
                
            }
        }
