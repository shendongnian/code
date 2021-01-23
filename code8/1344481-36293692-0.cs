                XmlReader reader = XmlReader.Create(url);
                reader.MoveToContent();
                while (!reader.EOF)
                {
                    reader.ReadToFollowing("job");
                    if (!reader.EOF)
                    {
                        ds.ReadXml(xmlReader);
                    }
                }
