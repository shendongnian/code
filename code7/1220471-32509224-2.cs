    public class AnimalResult : IHttpActionResult
    {
        [IgnoreDataMember]
        public HttpStatusCode StatusCode = HttpStatusCode.OK;
        [IgnoreDataMember]
        public HttpRequestMessage Request = null;
        private static HttpResponseMessage StaticCreateResponse<TAnimalResult>(TAnimalResult animalResult) where TAnimalResult : AnimalResult
        {
            Debug.Assert(typeof(TAnimalResult) == animalResult.GetType());
            return animalResult.Request.CreateResponse(animalResult.StatusCode, animalResult);
        }
        HttpResponseMessage CreateResponse()
        {
            if (Request == null)
                return null;
            else
            {
                var method = typeof(AnimalResult).GetMethod("StaticCreateResponse", BindingFlags.NonPublic | BindingFlags.Static);
                var genericMethod = method.MakeGenericMethod(new[] { GetType() });
                return (HttpResponseMessage)genericMethod.Invoke(null, new object[] { this });
            }
        }
        public Task<HttpResponseMessage> ExecuteAsync( CancellationToken cancellationToken )
        {
            var response = CreateResponse();
            return Task.FromResult( response );
        } // ExecuteAsync()
    }
