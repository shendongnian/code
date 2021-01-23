        public static string ToXMLString(object item)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(item.GetType());
            serializer.Serialize(stringwriter, item);
            return stringwriter.ToString();
        }
