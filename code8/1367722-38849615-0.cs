    private static XmlDocument CreateSoapEnvelope(string OPname, List<SOAPDataClass> Parameters)
        {
            XmlDocument soapEnvelop = new XmlDocument();
            string xml = string.Concat("<?xml version=\"1.0\" encoding=\"utf-8\"?><soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\"><soap12:Body><", OPname, " xmlns=\"http://tempuri.org/\">");
            for (int i = 0; i < Parameters.Count; i++)
            {
                if (!string.IsNullOrEmpty( Parameters[i].Value) )
                {
                    if (Parameters[i].Value.Contains("<") || Parameters[i].Value.Contains(">"))
                        xml = string.Concat(xml, "<", Parameters[i].Properties, ">", @"<![CDATA[", @Parameters[i].Value, "]]>", "</", Parameters[i].Properties, ">");
                    else
                        xml = string.Concat(xml, "<", Parameters[i].Properties, ">",  @Parameters[i].Value,  "</", Parameters[i].Properties, ">");
                }
                else
                    xml = string.Concat(xml, "<", Parameters[i].Properties, "/>");
            }
            xml = string.Concat(xml, "</", OPname, "></soap12:Body></soap12:Envelope>"); ;
            soapEnvelop.LoadXml(xml);
            return soapEnvelop;
        }
