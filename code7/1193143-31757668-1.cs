    private bool TryGetValidDocument(string publicKey, XmlDocument doc)
    {
        var rsa = new RSACryptoServiceProvider();
        rsa.FromXmlString(publicKey);
    
        var nsMgr = new XmlNamespaceManager(doc.NameTable);
        nsMgr.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");
    
        var signedXml = new SignedXml(doc);
        var sig = (XmlElement) doc.SelectSingleNode("//sig:Signature", nsMgr);
        if (sig == null)
        {
            Console.WriteLine("Could not find the signature node");
            return false;
        }
        signedXml.LoadXml(sig);
    
        return signedXml.CheckSignature(rsa);
    }
