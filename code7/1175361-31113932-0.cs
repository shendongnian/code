        try
        {
          // your code here
        }                
        catch (WebException e2)
        {
           using (WebResponse response = e2.Response)
            {
             HttpWebResponse httpResponse = (HttpWebResponse)response;
             Console.WriteLine(" Error : {0}", httpResponse.StatusCode);
             using (Stream data = response.GetResponseStream())
             using (var reader = new StreamReader(data))
             {  
    //the html content is here
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
             }
            }
    }
