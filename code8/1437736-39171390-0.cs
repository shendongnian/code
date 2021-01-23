    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private List<string> m_conversationIds;
        public MessagesController()
        {
            m_conversationIds = new List<string>();
        }
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type != ActivityTypes.Message)
            {
                return await HandleSystemMessage(activity);
            }
            // ...
        }
        private async Task<HttpResponseMessage> HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.ConversationUpdate)
            {
                m_conversationIds.Add(message.Conversation.Id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            // ...
        }
    }
