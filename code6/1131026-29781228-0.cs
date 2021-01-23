    [Serializable()]   
    public abstract class BaseRequest
    {
    ...
    }
    
    [XmlRoot("EXTSYSTEM", Namespace="")]
    public class ResponseMessageEnvelope
    {
    
        [XmlElement("REQUEST")]
        public Request.BaseRequest Request
        {
            get;
            set;
        }
    
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
            XmlAttributes attrs = new XmlAttributes();           
            XmlElementAttribute attr = new XmlElementAttribute();
            attr.ElementName = "REQUEST";
            attr.Type = this.Request.GetType();
            attr.Namespace = "";
            attrs.XmlElements.Add(attr);
            attrOverrides.Add(typeof(ResponseMessageEnvelope), "Request", attrs);
            using (XmlWriter sWriter = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true ,Indent = true }))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ResponseMessageEnvelope), attrOverrides);
                serializer.Serialize(sWriter, this, ns);                
                return sb.ToString();
            }
        }
