    public class Rates : List<Rate>, IXmlSerializable
    {
        public Rates() : base() { }
        public Rates(IEnumerable<Rate> collection) : base(collection) { }
        #region IXmlSerializable Members
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            // for the `decodeName` delegate, you could check that the node name matches the pattern "rateN" for some integer N, if you want.
            XmlKeyValueListHelper.ReadXml(reader, this, null, s => new Rate { RateValue = s });
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            XmlKeyValueListHelper.WriteXml(writer, this, (i, rate) => "rate" + XmlConvert.ToString(i), r => r.RateValue);
        }
        #endregion
    }
    public class Rate
    {
        public string RateValue;
    }
    public static class XmlKeyValueListHelper
    {
        const string XsiNamespace = @"http://www.w3.org/2001/XMLSchema-instance";
        const string XsiNil = "nil";
        public static void WriteXml<T>(XmlWriter writer, IEnumerable<T> collection, Func<int, T, string> encodeName, Func<T, string> encodeValue)
        {
            int i = 0;
            foreach (var item in collection)
            {
                writer.WriteStartElement(XmlConvert.EncodeLocalName(encodeName(i, item)));
                if (item == null)
                {
                    writer.WriteAttributeString(XsiNil, XsiNamespace, XmlConvert.ToString(true));
                }
                else
                {
                    writer.WriteValue(encodeValue(item) ?? "");
                }
                writer.WriteEndElement();
                i++;
            }
        }
        public static void ReadXml<T>(XmlReader reader, ICollection<T> collection, Func<int, string, bool> decodeName, Func<string, T> decodeValue)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            int i = 0;
            reader.ReadStartElement(); // Advance to the first sub element of the list element.
            while (reader.NodeType == XmlNodeType.Element)
            {
                var key = XmlConvert.DecodeName(reader.Name);
                if (decodeName == null || decodeName(i, key))
                {
                    var nilValue = reader[XsiNil, XsiNamespace];
                    if (!string.IsNullOrEmpty(nilValue) && XmlConvert.ToBoolean(nilValue))
                    {
                        collection.Add(default(T));
                        reader.Skip();
                    }
                    else
                    {
                        string value;
                        if (reader.IsEmptyElement)
                        {
                            value = string.Empty;
                            // Move past the end of item element
                            reader.Read();
                        }
                        else
                        {
                            // Read content and move past the end of item element
                            value = reader.ReadElementContentAsString();
                        }
                        collection.Add(decodeValue(value));
                    }
                }
                else
                {
                    reader.Skip();
                }
                i++;
            }
            // Move past the end of the list element
            reader.ReadEndElement();
        }
    }
