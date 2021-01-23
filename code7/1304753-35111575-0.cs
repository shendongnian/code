    byte[] dataArray = Encoding.UTF8.GetBytes("");
    
    //url = "http://localhost:50036/UI/Dashboard.aspx?Action=FindControl"
    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
    httpRequest.Method = "POST";
    httpRequest.ContentType = "application/x-www-form-urlencoded";
    
    httpRequest.ContentLength = dataArray.Length;
    Stream requestStream = httpRequest.GetRequestStream();
    requestStream.Write(dataArray, 0, dataArray.Length);
    requestStream.Flush();
    requestStream.Close();
    
    HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse();
    
    if (httpRequest.HaveResponse == true)
    {
          Stream responseStream = webResponse.GetResponseStream();
          StreamReader responseReader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
          String responseString = responseReader.ReadToEnd();
          /*
              In responseString string i have all control and types seperated by `semicolon`(`;`)
          */
    }
    else
          Console.Write("no response");
