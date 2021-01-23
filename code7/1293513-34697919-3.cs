     HtmlWeb web = new HtmlWeb();
     HttpStatusCode statusCode = HttpStatusCode.OK;
     web.PostRequestHandler += (request, response) =>
     {
         if (response != null)
         {
             statusCode = response.StatusCode;
         }
     }
     var doc = web.Load(completeUrl)
     if (statusCode == HttpStatusCode.OK)
     {
         // received a read document
     }
 
