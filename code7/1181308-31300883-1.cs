    string sourceFileUrl="<MY URL>/SourcePage.aspx";
    Stream responseStream = WebRequest.Create(sourceFileUrl).GetResponse().GetResponseStream();
    using (StreamReader sr = new StreamReader(responseStream))
    {
        byte[] htmlBytes = Encoding.ASCII.GetBytes(sr.ReadToEnd());
        string filename = AppDomain.CurrentDomain.BaseDirectory + @"Temp\";
        fileName += Guid.NewGuid().ToString() +Path.GetExtension(sourceFileUrl);
        System.IO.File.WriteAllBytes(fileName, htmlBytes );
    }
