    public override Task WriteToStreamAsync(Type type, object value, Stream  writeStream, HttpContent content, TransportContext transportContext)
        {
            return Task.Factory.StartNew(() =>
            {
                XmlSerializer xs = new XmlSerializer(type);
                XmlDocument temp = new XmlDocument();   //create a temporary xml document
                var navigator = temp.CreateNavigator(); //use its navigator
                using (var w = navigator.AppendChild()) //to get an XMLWriter
                    xs.Serialize(w, value);              //serialize your data to it
                XmlDocument xdoc = new XmlDocument();   //init the main xml document
                 //add xml declaration to the top of the new xml document
                xdoc.AppendChild(xdoc.CreateXmlDeclaration("1.0", "utf-8", null));
                //create the root element
                var animal = xdoc.CreateElement("Animal");
                animal.InnerXml = temp.InnerXml;   //copy the serialized content
                xdoc.AppendChild(animal);
                using (var xmlWriter = new XmlTextWriter(writeStream, encoding))
                {
                    xdoc.WriteTo(xmlWriter);
                }
            });
        }
