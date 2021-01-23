        public HttpResponseMessage Get(string appKey, string qs1 = null, string qs2 = null)
        {
            
            var remess = new HttpResponseMessage { RequestMessage = Request, StatusCode = HttpStatusCode.OK };
            if (qs1 == null || qs2 == null)
            {
                remess.Content = new StringContent("-1", Encoding.UTF8, "text/plain");
            }
            else if ( true == new BusinessClass().ValueCheck( appKey , qs1 , qs2 ) )
            {
                remess.Content = new StringContent("1", Encoding.UTF8, "text/plain");
            }
            else
            {
                remess.Content = new StringContent("0", Encoding.UTF8, "text/plain");
            }
            return remess;
        }
