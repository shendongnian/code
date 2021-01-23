    var encoding = ASCIIEncoding.ASCII;
    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
    {
        string responseText = reader.ReadToEnd();
    }
