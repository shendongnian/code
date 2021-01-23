    string soap = "<?xml version='1.0'?> " +
                            "<soapenv:Envelope xmlns:ns='http://www.buzonfiscal.com/ns/xsd/bf/bfcorp/32' xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/'> " +
                            "<soapenv:Header/> " +
                            "<soapenv:Body> " +
                            "<ns:RequestCancelaCFDi uuid='" + this.txtUUID.Text + "' rfcReceptor='" + this.txtReceptor.Text + "' rfcEmisor='" + this.txtEmisor.Text + "'/> " +
                            "</soapenv:Body> " +
                            "</soapenv:Envelope> ";
            X509Certificate2 cert = new X509Certificate2(@"C:\test.pfx", "password");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://WebRequest.com/bfcorpcfdi32ws");
            req.ContentType = "text/xml";
            req.Method = "POST";
            req.ClientCertificates.Add(cert);
 
            MessageBox.Show(soap);
            using (Stream stm = req.GetRequestStream())
            {
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(soap);
                    stmw.Close();
                }
            }
            try
            {
                WebResponse response = req.GetResponse();
                Stream responseStream = response.GetResponseStream();
                response = req.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string result = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                if (ex is WebException)
                {
                    WebException we = ex as WebException;
                    WebResponse webResponse = we.Response;
                    throw new Exception(ex.Message);
                }
            }
