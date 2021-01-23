     WebRequest request = WebRequest.Create(apiUrl);
     request.Method = "POST";
     request.ContentType = "application/json;charset=UTF-8";
     data = "[ \"89\", \"354\", \"AF001\" ]";
	 StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                    
     requestWriter.Write(data);
     requestWriter.Close();
      WebResponse response = request.GetResponse();
      Console.WriteLine(((HttpWebResponse)response).StatusDescription);
      response.Close();
      request = WebRequest.Create(url);
      request.Method = "POST";
      request.ContentType = "application/json;charset=UTF-8";
       StreamWriter requestWriter2 = new StreamWriter(request.GetRequestStream())
                   
       var data2 = ""[ \"55\", \"3524\", \"b01\" ]";
       requestWriter2.Write(data2);
       requestWriter2.Close();
       WebResponse response2 = request.GetResponse()
       Console.WriteLine(((HttpWebResponse)response2).StatusDescription);
