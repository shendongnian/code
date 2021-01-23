        public class AnimalReturn<TProperties> : AnimalResult<AnimalReturn<TProperties>>
        {
            public TProperties Properties;
        }
    
        public class AnimalResult<T> : IHttpActionResult
            where T : class
        {
            [IgnoreDataMember]
            public HttpStatusCode StatusCode = HttpStatusCode.OK;
    
            [IgnoreDataMember]
            public HttpRequestMessage Request = null;
    
            public Task<HttpResponseMessage> ExecuteAsync( System.Threading.CancellationToken cancellationToken )
            {
                HttpResponseMessage response = null;
                if( null != Request )
                {
                    response = Request.CreateResponse( StatusCode, this as T );
                }
                return Task.FromResult( response );
            } // ExecuteAsync()
        }
