        [Route("ProcessMessage")]
        public async void ProcessMessage(string[] clientConnectionStrings)
        {
            // do some processing
            var hub = GlobalHost.ConnectionManager.GetHubContext<MessagingHub>();
            hub.Clients.AllExcept(clientConnectionStrings);
        }
