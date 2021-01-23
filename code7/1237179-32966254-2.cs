    void Main()
            {
                var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ScaleFactors CorrectionFactorX=\"1.31\" CorrectionFactorY=\"1\" CorrectionFactorZ=\"1\" />";
                using (var reader = XmlReader.Create(new StringReader(xml)))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            Console.WriteLine(reader.Name);
                            var attc = reader.AttributeCount;
                            for (int i = 0; i < attc; i++)
                            {
                                Console.WriteLine(reader.GetAttribute(i));
                            }
                        }
                    }
                }
            }
