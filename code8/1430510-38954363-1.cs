        [JsonConverter(typeof(PropertyNamesSerializer))]
        public class UserCredentials
        {
            [JsonProperty("InternetGatewayDevice.WANDevice.1.WANConnectionDevice.1.WANPPPConnection.1.Username")]
            public string Username { get; set; }
            [JsonProperty("InternetGatewayDevice.WANDevice.1.WANConnectionDevice.1.WANPPPConnection.1.Password")]
            public string Password { get; set; }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine(JsonConvert.SerializeObject(new UserCredentials() {Username = "test", Password = "something"}));
        }
