          ServicePointManager.DefaultConnectionLimit = 50;
          var url = "http://localhost/HttpTaskServer/default.aspx";
    
          var iterations = 1000;
          for (int i = 0; i < iterations; i++)
          {
            var postParameters = new NameValueCollection();
            postParameters.Add("data", i.ToString());
            HttpSocket.PostAsync(url, postParameters, callbackState =>
              {
                if (callbackState.Exception != null)
                  throw callbackState.Exception;
                Console.WriteLine(HttpSocket.GetResponseText(callbackState.ResponseStream));
              });
          }
