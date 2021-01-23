        [JsonObject(MemberSerialization.OptIn)]
        private class UserData
        {
            [JsonProperty]      
            public string Token { get; set; }
            
            [JsonProperty]
            public string Username { get; set; }
            [JsonIgnore]
            [JsonProperty]
            public string Password { get; set; }
        }
