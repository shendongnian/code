     object nativeObject = Dts.Connections["Webservice"].AcquireConnection(null);
     HttpClientConnection conn = new HttpClientConnection(nativeObject);
     Service ws = new Service(conn.ServerURL);
     securityRequest req = new securityRequest();
     req.username = "****";
     req.password = "****";
          
     securityResponse response = ws.GetSecurityResp(req);
     System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(response.GetType());
     StringWriterWithEncoding responseToXml = new StringWriterWithEncoding(new StringBuilder(), Encoding.UTF8);
     x.Serialize(responseToXml, response);
     Dts.Variables["User::securityResponse"].Value = responseToXml.ToString();
     Dts.TaskResult = (int)ScriptResults.Success;
