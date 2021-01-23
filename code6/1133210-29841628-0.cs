    HttpWebResponse httpResponse = null;
    try
    {
        httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            string result = streamReader.ReadToEnd();
            Console.WriteLine(result);
        }
    }
    catch (WebException e)
    {
       Console.WriteLine(e.ToString());
    
       string responseText;
       using (var reader = new StreamReader(webException.Response.GetResponseStream()))
       {
           responseText = reader.ReadToEnd();
       }
    
       Console.WriteLine("WebException caught. Response text is {0}", responseText);
    }
