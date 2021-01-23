    StreamReader objSR = new StreamReader(response.GetResponseStream()); //get the soap from a server
                string strResponse = objSR.ReadToEnd();
                  XmlReader reader = XmlReader.Create(new StringReader(strResponse));
                while (reader.Read())
                {
                    if(reader.HasAttributes)
                      Console.WriteLine(reader.GetAttribute("Type"));
                    Console.WriteLine( reader.Value);
                }
