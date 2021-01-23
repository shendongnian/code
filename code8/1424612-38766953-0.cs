    public class MessagesController : ApiController {
        //POST api/messages
        [HttpPost, Route("Messages")]
        public HttpResponseMessage Post([FromBody] PostMessageDto message) {
            var entity = new Message {
                Content = message.Content,
                To = message.To
            };
            messageRepository.Create(entity);
            return Request.CreateResponse(HttpStatusCode.Created, "Message was send.");
        }
        //GET api/messages    
        [HttpGet, Route("Messages")]
        public HttpResponseMessage Get() {
            var entities = messageRepository.GetMessages();
            //..you can put code here that creates the data you want returned.
            var responseData= entities.Select(x => new {
                Content = x.Content,
                To = x.To,
                From = x.From,
                Time = x.Time
            });
            
            var response = Request.CreateResponse(HttpStatusCode.OK, responseData);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }
    }
