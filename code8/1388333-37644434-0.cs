        public async Task<HttpResponseMessage> Get(MessageConfig config)
        {
            HttpResponseMessage response = null;
            string theMessage = null;
            if (!config.IsValid)
            {
               log.Error(Message);
               return error response;
            } 
               ...........
        }
