    public static string Serialize(this IExtensibleDataObject obj, bool indent = false)
        {
            DataContractSerializer contractSerializer = new DataContractSerializer(obj.GetType());
            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                {
                    if (indent)
                    {
                        xmlTextWriter.Formatting = Formatting.Indented;
                        xmlTextWriter.Indentation = 2;
                    }
                    contractSerializer.WriteObject(xmlTextWriter, obj);
                    return stringWriter.ToString();
                }
            }
        }
