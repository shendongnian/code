    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        [Route("myMessage/{message}")]
        [AcceptVerbs("GET", "POST")]
        [HttpPost]
        public string myMessage(string message)
        {
            return message;
        }
    }
