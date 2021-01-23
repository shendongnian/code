        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        [Route("messages/{*wildcard}")]
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
