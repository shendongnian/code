        async Task BigFileReader(System.IO.Stream stream)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Async = true;
            bool bIdEncountered = false;
            using (XmlReader reader = XmlReader.Create(stream, settings))
            {
                while (await reader.ReadAsync())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            bIdEncountered = reader.LocalName.Equals("id");
                            break;
                        case XmlNodeType.Text:
                            var value = await reader.GetValueAsync();
                            if(bIdEncountered) Console.WriteLine("Run my SQL for {0}", value);
                            break;
                        case XmlNodeType.EndElement:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
