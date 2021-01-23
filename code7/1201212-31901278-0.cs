                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://schemas.datacontract.org/2004/07/WcfWebService");
                var ser = new XmlSerializer(typeof(GetAccountCreditParams));
                using (var writer = new StringWriter())
                {
                    ser.Serialize(writer, new GetAccountCreditParams { Password = "pass", UserName = "use" },namespaces);
                    var xml = writer.ToString();
                }
    
      
    
        [XmlRoot(ElementName = "WS_IN_GetAccountCredit", Namespace = "http://schemas.datacontract.org/2004/07/WcfWebService")]
        public class GetAccountCreditParams
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
