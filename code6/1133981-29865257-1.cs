    private string ApiQuery(string url)
    {
       HttpWebRequest requete = (HttpWebRequest)HttpWebRequest.Create(url);
       requete.Method = "POST";
       requete.ContentType = "application/x-www-form-urlencoded";
    
       using (var requestStream = requete.GetRequestStream())
       {
       	  // Write to request stream
       }
       
       using (var responseStream = requete.GetResponse())
       {
       	  // Read the respone stream, parsing out your JSON.
       }
    }
