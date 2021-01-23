        async Task BigFileReader(System.IO.Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = true;
            bool bIdEncountered = false;
            List<ImageNode> images = new List<ImageNode>();
            int artistId = 0;
            
            using (XmlReader reader = XmlReader.Create(stream, settings))
            {
                while (await reader.ReadAsync())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            bIdEncountered = reader.LocalName.Equals("id");
                            //bImageEncountered = reader.LocalName.Equals("image");
                            if(reader.LocalName.Equals("images")) images.Clear();
                            if (reader.LocalName.Equals("image"))
                            {
                                images.Add( new ImageNode
                                        {
                                            Width = Convert.ToInt32(reader.GetAttribute("width")),
                                            Height = Convert.ToInt32(reader.GetAttribute("height")),
                                            Url = reader.GetAttribute("uri")
                                        });
                            }
                            break;
                        case XmlNodeType.Text:
                            if (bIdEncountered) artistId = Convert.ToInt32(await reader.GetValueAsync());
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
    internal class ImageNode    
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Url { get; set; }
        public override string ToString() { return String.Format("{0}x{1}:{2}", Width, Height, Url); }
    }
