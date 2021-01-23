    public class RestClient
    {
        Action<HttpWebResponse> onSuccess;
        Action<HttpWebResponse> onError;
        Action<HttpWebResponse> onInternalServerError;
        public RestClient OnSuccess(Action<HttpWebResponse> Handler)
        {
            onSuccess = Handler;
            return this;
        }
        public RestClient OnError(Action<HttpWebResponse> Handler)
        {
            onError = Handler;
            return this;
        }
        public RestClient OnInternalServerError(Action<HttpWebResponse> Handler)
        {
            onInternalServerError= Handler;
            return this;
        }
        private async RequestTask<T> MakeGetRequest<T>(string endpoint, bool auth = true)
        {
           //lots of code, blablabla, just let's go on the handling
           switch(response.StatusCode)
           {
               case HttpStatusCode.OK:
                   if(onSuccess != null)
                       onSuccess(response);
                   break;
               case HttpStatusCode.InternalServerError:
                   if(onInternalServerError!= null)
                       onInternalServerError(response);
                   break;
               default:
                  if(onError!= null)
                       onError(response);
                   break;
           }
        }
    }
