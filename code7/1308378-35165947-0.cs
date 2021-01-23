    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Friends));
    using (MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(data)));
    {
  	Friends x = (Friends)js.ReadObject(ms);
    }
