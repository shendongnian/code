    private static string SignXml(XmlDocument xmlDoc)
    {
       ...
       return csp.ToXmlString(false);
    }
    public static Boolean VerifyXml(XmlDocument doc, string xmlKey)
    {
        RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
        csp.FromXmlString(xmlKey);
        ...
    }
    var xmlKey = SignXml(xml);
    var res = VerifyXml(xml, xmlKey);
