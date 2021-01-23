    xmlWriter.WriteAttributeString(MyXmlExtensions.EncodeXmlAttributeName("this is normally an invalid attribute name"), "value1");
    class MyXmlExtensions
    {
        public string EncodeXmlAttributeName(string decoded)
        {
            // not that you'll likely need to enhance this with whatever rules you want but haven't specified
            return decoded.Replace(" ", "_");
        }
        public string DecodeXmlAttributeName(string encoded)
        {
            // not that you'll likely need to enhance this with whatever rules you want but haven't specified
            return encoded.Replace("_", " ");
        }
    }
