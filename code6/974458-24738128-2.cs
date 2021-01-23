        async Task BigFileReader(System.IO.Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = true;
            bool bIdEncountered = false;
            bool bImageEncountered = false;
            List<string> images = new List<string>();
            int artistId = 0;
            using (XmlReader reader = XmlReader.Create(stream, settings))
            {
                while (await reader.ReadAsync())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            bIdEncountered = reader.LocalName.Equals("id");
                            bImageEncountered = reader.LocalName.Equals("image");
                            if(reader.LocalName.Equals("images")) images.Clear();
                            break;
                        case XmlNodeType.Text:
                            //var value = await reader.GetValueAsync();
                            if (bIdEncountered) artistId = Convert.ToInt32(await reader.GetValueAsync());
                            if (bImageEncountered) images.Add(await reader.GetValueAsync());
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
