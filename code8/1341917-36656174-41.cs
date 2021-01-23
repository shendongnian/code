    [Route("/api/sse")]
    public class ServerSentEventController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ServerSentEventController(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        public async Task Get()
        {
            var response = _httpContextAccessor.HttpContext.Response;
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
