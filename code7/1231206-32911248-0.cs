    List<QualityPageLink> linkListToRetrySync = new List<QualityPageLink>();
        ServicePointManager.DefaultConnectionLimit = 1000;
        Parallel.ForEach(
             linkList,
             //new ParallelOptions() { //MaxDegreeOfParallelism = 64 },
             link =>
             {
              HtmlAnalyzor htmlAnalyzor = new HtmlAnalyzor(link.URL);
              int statusCode = -1;
              for (int retryTime = 2; retryTime >= 0; retryTime--)
              {
                  statusCode = htmlAnalyzor.GetDestinationURLStatusCode(link.URL, link.IdQualityPage, retryTime);
                  if (statusCode > 0) { break; }
                  if (statusCode != 200) { linkListToRetrySync.Add(link); }
                  linkIdStatusCodeDic.Add(link, statusCode);
              });
    
    
    if(linkListToRetrySync!=null && linkListToRetrySync.Count()!=0)
    {
          for (int i = 0; i < linkListToRetrySync.Count(); i++)
          {
               var link = linkListToRetrySync[i];
               int statusCode = -1;
               HtmlAnalyzor htmlAnalyzor = new HtmlAnalyzor(link.URL);
               for (int retryTime = 2; retryTime >= 0; retryTime--)
               {
                   statusCode = htmlAnalyzor.GetDestinationURLStatusCode(link.URL, link.IdQualityPage, retryTime);
                   if (statusCode > 0) { break; }
               }
               linkIdStatusCodeDic[link] = statusCode;
                }
        }
     public int GetDestinationURLStatusCode(string originalURL, int qPageId, int retryTime)
            {
                HttpWebRequest request;
                int statusCode = -1;
                //HttpWebResponse response = null;
                try
                {
                    Console.WriteLine("URL:{0}", Helper.ToString(originalURL));
                    request = (HttpWebRequest)WebRequest.Create(originalURL);
                    request.UserAgent = "html-analyzor";
                    request.KeepAlive = false;
                    request.Timeout = 15000;
                using (this._Response = (HttpWebResponse)request.GetResponse())
                {
                    statusCode = (int)_Response.StatusCode;
                }
                
                //string destURL = _Response.ResponseUri.ToString();
                //if (originalURL != destURL)
                //{
                //    GetDestinationURLStatusCode(destURL, qPageId, retryTime);
                //}
                
                Console.WriteLine("Normal:{0}", statusCode);
                return statusCode;
            }
            catch (WebException webEx)
            {
                statusCode = 0;
                if (webEx.Status == WebExceptionStatus.ProtocolError)
                {
                    statusCode = (int)((HttpWebResponse)webEx.Response).StatusCode;
                    Console.WriteLine("WebEx:{0}", statusCode);
                }
                if (this._Response != null)
                {
                    this._Response.Close();
                    this._Response = null;
                }
                return statusCode;
            }
            catch(Exception ex)
            {
                if (this._Response != null)
                {
                    this._Response.Close();
                    this._Response = null;
                }
                if (retryTime == 0)
                {
                    // Console.WriteLine("Failed.");
                }
                return -1;
            }
        }
