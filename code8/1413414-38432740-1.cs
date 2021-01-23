        public void WriteIntoFile(string Message)
        {
            const string Path = "C:\\Temp\\Log.xml";
            XmlDocument MyDocument = new XmlDocument();
            MyDocument.Load(Path);
            XmlNode ExceptionsNode = MyDocument.CreateElement("Exceptions");
            XmlNode ExceptionNode = MyDocument.CreateElement("Exception");
            XmlNode MessageNode = MyDocument.CreateElement("Message");
            MessageNode.InnerText = Message;
            ExceptionNode.AppendChild(MessageNode);
            ExceptionsNode.AppendChild(ExceptionNode);
            MyDocument.AppendChild(ExceptionsNode);
        }
