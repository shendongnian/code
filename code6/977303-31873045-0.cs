     private string AddExIP(string viewerConnectionString)
            {
                TextReader tr = new StringReader(viewerConnectionString);
                XDocument doc = XDocument.Load(tr);
                //get the randomport
                string port = doc.Element("E")
                    .Element("C")
                    .Element("T")
                    .Element("L")
                    .Attribute("P").ToString().Replace("\"", "").Replace("P=","");
                int Intport = Convert.ToInt16(port);
                int count = Convert.ToInt16(doc.Descendants("L").ToList().Count);
                string Port = Convert.ToString(Intport + count);
    
                // get external ip 
                // From http://stackoverflow.com/a/16109156/2573450
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                string ExternalIp = a4;
    
                // Add to connection string
                doc.Element("E").Element("C").Element("T").Add(new XElement("L",
                    new XAttribute("P", Port),
                    new XAttribute("N", ExternalIp)
                    ));
                return doc.ToString();
            }
    string viewerConnString = Viewer.StartReverseConnectListener(SessionInvitation, Myname, Mypass);
    
    String NewConnectionString = AddExIP(viewerConnString);
