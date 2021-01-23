    using (Stream fileResponse = fileFtpRequest.GetResponse().GetResponseStream())
    using (var reader = new StreamReader(fileResponse)
    {
       string line;
       while ((line = reader.ReadLine()) != null)
       {
           something.WriteLine(line);  // here you get the .NET line ending
       }
    }
