        public List<Message> Messages { get; set; }
        public async Task getMessages()
        {
            await GetRemoteMessages();
        }
        private async Task GetRemoteMessages()
        {
            var remoteClient = new ChiesiClient();
            var messages = await remoteClient.getMessages().ConfigureAwait(false);
            //App.Database.
            SaveAll(messages);
        }
        public void SaveAll(IEnumerable<Message> _messages)
        {
            foreach (var item in _messages)
            {
                SaveMessage(item);
            }
        }
        public void SaveMessage(Message item)
        {
            Messages.Add(new Message // Cannot await void
            {
                Title = item.Title,
                Description = item.Description,
                Date = item.Date,
                Url = item.Url
            });
        }
