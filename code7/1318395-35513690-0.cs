       public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "column")
                {
                    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(EcomOrder));
                    string propName = reader.GetAttribute("columnName");
                    // Retrieve the property Descriptor
                    PropertyDescriptor prop = props[propName];
                  
                    if (prop != null)
                    {
                        reader.Read(); // move to CDATA (or text) node
                                       
                        // use DateTime.ParseExact instead for DateTime field
                        if (prop.PropertyType == typeof(DateTime?) || prop.PropertyType == typeof(DateTime))
                        {
                            prop.SetValue(this,
                                 DateTime.ParseExact(reader.Value, "dd-MM-yyyy HH:mm:ss:fff", CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            prop.SetValue(this,
                                 prop.Converter.ConvertFromInvariantString(reader.Value));
                        }
                    }
                    else
                    {
                        throw new XmlException("Property not found: " + propName);
                    }
                }
            }
        }
