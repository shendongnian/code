    [XmlRoot("item")]
    public class Order  : IXmlSerializable
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "column")
                {
                    string propName = reader.GetAttribute("columnName"); // get the property info...
                    PropertyInfo prop = typeof(Order).GetProperty(propName, 
                          BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
                    if (prop != null && prop.CanWrite)
                    {
                        reader.Read(); // move to CDATA (or text) node
                        // can use Convert.ChangeType for most types
                        // use DateTime.ParseExact instead for DateTime field
                        if (prop.PropertyType != typeof(DateTime))
                        {
                            prop.SetValue(this, 
                                 Convert.ChangeType(reader.Value, prop.PropertyType, CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            prop.SetValue(this, 
                                 DateTime.ParseExact(reader.Value,  "dd-MM-yyyy HH:mm:ss:fff", CultureInfo.CurrentCulture));
                        }
                    }
                    else
                    {
                        throw new XmlException("Property not found: " + propName);
                    }
                }                    
                    
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
