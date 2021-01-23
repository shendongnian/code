    else if (((!reader.IsStartElement("description"))
                            && (!reader.IsStartElement("source"))
                            && (!reader.IsStartElement("properties"))
                            && (!reader.IsStartElement("elements"))
                            && (!reader.IsStartElement("parameters"))
                            && (!XmlReader.IsName("job"))))
                        {
                            throw new XmlException("Unexpected element was present");
                        }
