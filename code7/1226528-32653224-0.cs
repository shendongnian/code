     HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(uri);
     var cache = new CredentialCache();
     cache.Add(new Uri(uri), "Digest", new NetworkCredential("administrator", "admin"));
     httpRequest.Credentials = cache;
     httpRequest.PreAuthenticate = true;
     using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
     {
        //DO CODE
     }
