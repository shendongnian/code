            var xml = GetXml(); // Your sample XML as a string
            int topLevelElementIndex = 1;
            var topLevelElementName = "QMXINVQ_INVENTORYType";
            try
            {
                using (var sr = new StringReader(xml)) // You would use e.g. var sr = new StreamReader(strRespFile, Encoding.Encoding.UTF8)
                using (var reader = XmlReader.Create(sr))
                {
                    // Move to ROOT Element
                    reader.MoveToContent();
                    Debug.Assert(reader.Name == "ArrayOfQMXINVQ_INVENTORYType"); // No assert.
                    // Read to first CHILD Element of the root
                    reader.Read(); // Read to the first child NODE of the root element
                    reader.MoveToContent(); // If that node is whitespace, skip to content.
                    // Read to the FIRST array element of the desired name.
                    if (reader.Name != topLevelElementName)
                        if (!reader.ReadToNextSibling(topLevelElementName))
                            throw new InvalidOperationException("Not enough elements named " + topLevelElementName);
                    // Now read to the Nth element of the desired name.
                    for (int i = topLevelElementIndex; i > 0; i--)
                        if (!reader.ReadToNextSibling(topLevelElementName))
                            throw new InvalidOperationException("Not enough elements named " + topLevelElementName);
                    // Process the Nth element as desired.
                    Debug.Assert(reader.NodeType == XmlNodeType.Element && reader.Name == topLevelElementName);
                    using (var subReader = reader.ReadSubtree())
                    {
                        var element = XElement.Load(subReader);
                        Debug.WriteLine(element.ToString());
                        // If each individual array element has manageable size, the easiest way to parse it is to load it into
                        // an XElement with a nested reader, then use Linq to XML
                        Debug.Assert(element.Descendants("BINNUM").Select(e => (string)e).FirstOrDefault() == "B-8-1"); // No assert.
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle errors in the file however you like.
                Debug.WriteLine(ex);
                throw;
            }
