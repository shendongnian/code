    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route]
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(
                (output, content, context) =>
                {
                    using (var writer = new StreamWriter(output))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            writer.WriteLine("Eh?");
                            writer.Flush();
                            Thread.Sleep(2000);
                        }
                    }
                },
                "text/event-stream");
    
            return response;
        }
    }
