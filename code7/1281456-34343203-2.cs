                System.Security.Cryptography.X509Certificates.X509Extension uccSan = mCert.Extensions["2.5.29.17"];
                if (uccSan != null)
                {
                    foreach (string nvp in uccSan.Format(true).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        writer.WriteStartElement("alternateName");
                        string[] parts = nvp.Split('=');
                        string name = parts[0];
                        string value = (parts.Length > 0) ? parts[1] : null;
                        writer.WriteAttributeString("type", name);
                        writer.WriteAttributeString("value", value);
                        writer.WriteEndElement(); // alternateName
                    }
                }
