    The following method streams through one of your XML files and returns your selected values in an `object[,] table`:
        const int ColumnLength = 58;
        const int ChaveIndex = 57;
        const int ItemIndex = 27;
        static bool TryExtractTable(string arquivo, out object[,] table)
        {
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe";
            var rootName = ns + "nfeProc";
            var chaveName = ns + "chNFe";
            var itemsName = ns + "det";
            try
            {
                using (var reader = XmlReader.Create(arquivo))
                {
                    // Move to the root element, verify it's correct.
                    if (!reader.ReadToElement() || reader.XName() != rootName)
                    {
                        table = null;
                        return false;
                    }
                    string chaveValue = null;
                    List<object> itemValues = new List<object>();
                    bool alreadyReadNext = false;
                    while (alreadyReadNext || reader.Read())
                    {
                        alreadyReadNext = false;
                        if (reader.NodeType != XmlNodeType.Element)
                            continue;
                        var name = reader.XName();
                        if (chaveValue == null && name == chaveName)
                        {
                            chaveValue = ((XElement)XNode.ReadFrom(reader)).Value;
                            // XNode.ReadFrom advances the reader to the next node after the end of the current element.  
                            // Thus a subsequent call to reader.Read() would skip this node, and so should not be made.
                            alreadyReadNext = true;
                        }
                        else if (name == itemsName)
                        {
                            // Access the "nItem" attribute directly.
                            var itemValue = reader["nItem"];
                            itemValues.Add(itemValue);
                        }
                    }
                    if (itemValues.Count > 0)
                    {
                        var nRows = itemValues.Count;
                        table = new object[nRows, ColumnLength];
                        for (int iRow = 0; iRow < nRows; iRow++)
                        {
                            table[iRow, ChaveIndex] = chaveValue;
                            table[iRow, ItemIndex] = itemValues[iRow];
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            table = null;
            return false;
        }
    Using the extension methods:
        public static class XmlReaderExtensions
        {
            public static XName XName(this XmlReader reader)
            {
                return System.Xml.Linq.XName.Get(reader.Name, reader.NamespaceURI);
            }
            public static bool ReadToElement(this XmlReader reader)
            {
                while (reader.NodeType != XmlNodeType.Element)
                    if (!reader.Read())
                        return false;
                return true;
            }
        }
