     string url = string.Format("{0}{1}", str_baseURL, resource.ToString());
            if (argument != null)
            {
                method = "POST";
                //url = string.Format("{0}{1}/", url, argument); 
            }
            else
            {
                method = "GET";
            }
            data = argument;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.ContentType = "application/json";
            request.Method = method;
