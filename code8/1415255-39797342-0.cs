        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity reply = activity.CreateReply($" Hello");
                reply.Attachments = new List<Attachment>();  //****** INIT
                reply.Attachments.Add(new Attachment()
                {
                    ContentUrl = $"https://upload.wikimedia.org/wikipedia/en/a/a6/Bender_Rodriguez.png",
                    ContentType = "image/png",
                    Name = "Bender_Rodriguez.png"
                });
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
