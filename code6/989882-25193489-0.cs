    public class UsersController : ApiController
    {
        private IDirectorySearcher _searcher;
        public UsersController(IDirectorySearcher searcher)
        {
            _searcher = searcher;
        }
        // GET api/users/?username=admin
        public SearchResult Get([FromUri]string userName)
        {
            try
            {
                return _searcher.FindSAMAccountName(userName);
            }
            catch (ADException ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = ex.Content,
                    ReasonPhrase = ex.Reason
                };
                throw new HttpResponseException(response);
            }
        }
    }
