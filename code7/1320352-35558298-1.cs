    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Project>));
        
    string result = string.Empty;
    using (MemoryStream ms = new MemoryStream())
    {
       try
       {
          serializer.WriteObject(ms, this);
          ms.Position = 0;
          using (StreamReader sr = new StreamReader(ms))
          {
             result = sr.ReadToEnd();
          }
       }
       catch (Exception ex)
       {
          // your exception handling
       }
    }
