    public class CustomRequestSerializer: WSTrust13RequestSerializer
    {
        public override void WriteXmlElement(XmlWriter writer, string elementName, object elementValue, RequestSecurityToken rst,
            WSTrustSerializationContext context)
        {
            var parameters = new string[1] {"paramname"};
            if (parameters.Any(p => p == elementName))
            {
                writer.WriteElementString(elementName, (string)elementValue);
            }
            else
            {
                base.WriteXmlElement(writer, elementName, elementValue, rst, context);
            }
        }
        public override void ReadXmlElement(XmlReader reader, RequestSecurityToken rst, WSTrustSerializationContext context)
        {
            var parameters = new string[1] {"paramname"};
            var key = parameters.FirstOrDefault(reader.IsStartElement);
            if (!string.IsNullOrWhiteSpace(key))
            {
                rst.Properties.Add(key, reader.ReadElementContentAsString());
                return;
            }
            base.ReadXmlElement(reader, rst, context);            
        }
    }
