        static void BigFileReader(System.IO.Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            bool bIdEncountered = false;
            List<ImageNode> images = new List<ImageNode>();
            int artistId = 0;
            using (XmlReader reader = XmlReader.Create(stream, settings))
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            bIdEncountered = reader.LocalName.Equals("id");
                            //bImageEncountered = reader.LocalName.Equals("image");
                            if (reader.LocalName.Equals("images")) images.Clear();
                            if (reader.LocalName.Equals("image"))
                            {
                                images.Add(new ImageNode
                                {
                                    Width = Convert.ToInt32(reader.GetAttribute("width")),
                                    Height = Convert.ToInt32(reader.GetAttribute("height")),
                                    Url = reader.GetAttribute("uri")
                                });
                            }
                            break;
                        case XmlNodeType.Text:
                            if (bIdEncountered) artistId = Convert.ToInt32(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            if (reader.LocalName.Equals("artist")) Console.WriteLine("Saving artist {0} with images {1}", artistId, String.Join(",", images));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
