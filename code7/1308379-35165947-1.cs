    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(RootObject));
    using (MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(data)));
    {
  	RootObject x = (RootObject)js.ReadObject(ms);
    }
