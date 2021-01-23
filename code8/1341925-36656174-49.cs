    [Route("/api/sse")]
    public class ServerSentEventController : Controller
    {
        [HttpGet]
        public async Task Get()
        {
            var response = Response;
            response.Headers.Add("Content-Type", "text/event-stream");
            for(var i = 0; true; ++i)
            {
                await response
                    .WriteAsync($"data: Controller {i} at {DateTime.Now}\r\r");
                    
                response.Body.Flush();
                await Task.Delay(5 * 1000);
            }
        }
    }
