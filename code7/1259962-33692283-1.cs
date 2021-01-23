    public class CustomSignedXml : SignedXml
    {
        XmlDocument xmlDocumentToSign;
        public CustomSignedXml(XmlDocument xmlDocument) : base(xmlDocument)
        {
            xmlDocumentToSign = xmlDocument;
        }
        public override XmlElement GetIdElement(XmlDocument document, string idValue)
        {
            XmlElement matchingElement = null;
            try
            {
                matchingElement = base.GetIdElement(document, idValue);
            }
            catch (Exception idElementException)
            {
                Trace.TraceError(idElementException.ToString());
            }
            if (matchingElement == null)
            {
                // at this point, idValue = xpointer(//*[@authenticate='true'])
                string customXPath = idValue.TrimEnd(')');
                customXPath = customXPath.Substring(customXPath.IndexOf('(') + 1);
                matchingElement = xmlDocumentToSign.SelectSingleNode(customXPath) as XmlElement;
            }
            return matchingElement;
        }
    }
