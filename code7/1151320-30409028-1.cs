    'public void ProcessRequest(HttpContext context)
            {            
                string responseText = "";
                if (context.Request.QueryString["a"].ToString() == "register")
                {
                    responseText = RegisterCard(context.Request.QueryString["data"].ToString());
                }
                context.Response.Write(responseText);
            }
    
            private string RegisterCard(string data)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://psp.sandbox.dev.skrillws.net/v1/json/3e40a821/channelid_register_get/creditcard/");
                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "POST";
    
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = data;
                    streamWriter.Write(json);
                }
                var responseText = "";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    responseText = streamReader.ReadToEnd();
                    //Now you have your response.
                    //or false depending on information in the response
                }
                return responseText;
            }
    '
