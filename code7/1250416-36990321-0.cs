    internal class ChangedWebServiceClient : SomeSoapService
    {
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var response = base.GetWebResponse(request);
            if (response != null)
            {
                var responseField = response.GetType().GetField("_base", BindingFlags.Instance | BindingFlags.NonPublic);
                if (responseField != null)
                {
                    var webResp = responseField.GetValue(response) as HttpWebResponse;
                    if (webResp != null)
                    {
                        if (webResp.StatusCode.Equals(HttpStatusCode.InternalServerError))
                            throw new WebException(
                                "HTTP 500 - Internal Server Error happened here. Or any other message that fits here well :)");
                    }
                }
            }
            return response;
        }
    }
