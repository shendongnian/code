    public class DecompressWebClient:WebClient
    {
        // moved common logic here
        public DecompressWebClient()
        {
            this.Encoding = Encoding.UTF8;
        }
        
        // This is the factory to create the webrequest
        protected override WebRequest GetWebRequest(Uri address)
        {
            // get the default one
            var request = base.GetWebRequest(address);
            // see if it is a HttpWebRequest
            var httpReq = request as HttpWebRequest;
            if (httpReq != null)
            {
                // add extra capabilities, like decompression
                httpReq.AutomaticDecompression =  DecompressionMethods.GZip;
            }
            return request;
        }
    }
