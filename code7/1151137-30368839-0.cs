    public class Employee : IXmlSerializable
    {
        public string Name { get; set; }
    
        public string Phone { get; set; }
    
        public DateTime? DOB { get; set; }
    
        public int? Id { get; set; }
    
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (string.Equals(reader.Name, "item", StringComparison.InvariantCultureIgnoreCase))
                        {
                            // move to 'key'
                            reader.Read();
                            if (reader.Name != "key") throw new SerializationException();
                            string key = reader.ReadElementContentAsString();
                            if (reader.Name != "value") throw new SerializationException();
                            switch (key)
                            {
                                case "Name":
                                    this.Name = reader.ReadElementContentAsString();
                                    break;
                                case "Phone":
                                    this.Phone = reader.ReadElementContentAsString();
                                    break;
                                case "Date of Birth":
                                    this.DOB = DateTime.Parse(reader.ReadElementContentAsString());
                                    break;
                                case "Employee ID":
                                    this.Id = reader.ReadElementContentAsInt();
                                    break;
                            }
                        }
                        else
                        {
                            // something was wrong
                            throw new SerializationException();
                        }
                        break;
                    case XmlNodeType.EndElement:
                        reader.Read();
                        return;
                }
            }
        }
    
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
