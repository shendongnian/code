                XmlReader reader = XmlReader.Create("filename");
                while(!reader.EOF)
                {
                    if(reader.Name != "InformationTuple")
                    {
                       reader.ReadToFollowing("InformationTuple");
                    }
                    if(!reader.EOF)
                    {
                         XElement subtree = (XElement)XElement.ReadFrom(reader);
                    }
                }
