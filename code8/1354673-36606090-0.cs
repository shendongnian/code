    class MyData
    {
         public byte[] XmlData { get; set; }
         [NotMapped]
         public XmlDocument XmlDocument 
         {
             get
             {
                 var doc = new XmlDocument();
                 var ms = new MemoryStream(this.XmlData);
                 doc.Load(ms);
                 return doc;
             }
             set 
             {
                 this.XmlData = Encoding.Default.GetBytes(value.OuterXml)
             }
         } 
    }
