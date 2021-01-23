        static string getEncoding(XmlDocument xml)
        {
            if (xml.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                return (xml.FirstChild as XmlDeclaration).Encoding;
            }
            return "utf-8";
        }
            
