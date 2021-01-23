    string sourceFileUrl="<MY URL>/SourcePage.aspx";
    string sourceFileExtension= Path.GetExtension(sourceFileUrl);
    Stream responseStream = WebRequest.Create(sourceFileUrl).GetResponse().GetResponseStream();
    using (StreamReader sr = new StreamReader(responseStream))
    {
        byte[] htmlBytes = Encoding.ASCII.GetBytes(sr.ReadToEnd());
        string filename = AppDomain.CurrentDomain.BaseDirectory + @"Temp\";
        fileName += Guid.NewGuid().ToString() + sourceFileExtension;
        System.IO.File.WriteAllBytes(fileName, htmlBytes );
    }
