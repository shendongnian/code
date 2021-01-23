    [RoutePrefix("api/GameSettings")]
    public class GameSettingsController
    {
        // GET /api/GameSettings
        public HttpResponseMessage Get()
        {
            // Magic
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        
        [Route("{category}")]
        public HttpResponseMessage Get(string category)
        {
            // Similar.
        }
    
        [Route("{category}/{key}")]
        public HttpResponseMessage Get(string category, string key)
        {
            // Slightly different, but still similar.
        }
    }
