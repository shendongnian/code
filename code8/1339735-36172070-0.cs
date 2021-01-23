     WebRequest req = null;
     WebResponse rsp = null;
     try
     {
      string fileName = "C:\test.xml";
      string uri = "http://localhost/PostXml/Default.aspx";
      req = WebRequest.Create(uri);
      //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
      req.Method = "POST";        // Post method
      req.ContentType = "text/xml";     // content type
      // Wrap the request stream with a text-based writer
      StreamWriter writer = new StreamWriter(req.GetRequestStream());
      // Write the XML text into the stream
      writer.WriteLine(this.GetTextFromXMLFile(fileName));
      writer.Close();
      // Send the data to the webserver
      rsp = req.GetResponse();
    
     }
     catch(WebException webEx)
     {
    
     }
     catch(Exception ex)
     {
    
     }
     finally
     {
      if(req != null) req.GetRequestStream().Close();
      if(rsp != null) rsp.GetResponseStream().Close();
     }
    private string GetTextFromXMLFile(string file)
    {
     StreamReader reader = new StreamReader(file);
     string ret = reader.ReadToEnd();
     reader.Close();
     return ret;
    }
