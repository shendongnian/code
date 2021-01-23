    [Route("api/YOURCONTROLLER/{paramOne}/{paramTwo}")]
        public string Get(int paramOne, int paramTwo)
        {
            return "The [Route] with multiple params worked";
        }
