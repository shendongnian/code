        [XmlRoot(ElementName = "WS_IN_GetAccountCredit", Namespace = "http://schemas.datacontract.org/2004/07/WcfWebService")]
        public class WS_IN_GetAccountCredit
        {
            private WS_IN_WebServiceIdentity wsIdentity;
            private WS_IN_GetAccountCreditParams getAccountCreditParams;
            public WS_IN_WebServiceIdentity WSIdentity { set { this.wsIdentity = value; } get { return this.wsIdentity; } }
            public WS_IN_GetAccountCreditParams GetAccountCreditParams
            {
                set { this.getAccountCreditParams = value; }
                get { return this.getAccountCreditParams; }
            }
    
    
        }
        public class WS_IN_WebServiceIdentity
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    
        public class WS_IN_GetAccountCreditParams
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
 
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://schemas.datacontract.org/2004/07/WcfWebService");
                var ser = new XmlSerializer(typeof(WS_IN_GetAccountCredit));
                using (var writer = new StringWriter())
                {
                    ser.Serialize(writer, new WS_IN_GetAccountCredit
                    {
                        GetAccountCreditParams = new WS_IN_GetAccountCreditParams { Password = "pass", UserName = "use" },
                        WSIdentity = new WS_IN_WebServiceIdentity { Password = "pass", UserName = "use" }
                    },
                        namespaces);
                    var xml = writer.ToString();
                }
