    public class ValuesController : ApiController
    {
        public async Task<HttpResponseMessage> Get( )
        {
            var work    = this.ActualWork( 5000 );
            var timeout = this.Timeout( 2000 );
            
            var finishedTask = await Task.WhenAny( timeout, work );
            if( finishedTask == timeout )
            {
                return this.Request.CreateResponse( HttpStatusCode.RequestTimeout );
            }
            else
            {
                return this.Request.CreateResponse( HttpStatusCode.OK, work.Result );
            }
        }
        private async Task<string> ActualWork( int sleepTime )
        {
            await Task.Delay( sleepTime );
            return "work results";
        }
        private async Task Timeout( int timeoutValue )
        {
            await Task.Delay( timeoutValue );
        }
    }
