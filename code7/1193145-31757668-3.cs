    private bool TryGetValidDocument(X509Certificate2 cert, XmlDocument doc)
    {
        var nsMgr = new XmlNamespaceManager(doc.NameTable);
        nsMgr.AddNamespace("sig", "http://www.w3.org/2000/09/xmldsig#");
    
        var signedXml = new SignedXml(doc);
        var sig = (XmlElement) doc.SelectSingleNode("//sig:Signature", nsMgr);
        if (sig == null)
        {
            Logger.Warn("Could not find the signature node");
            return false;
        }
        signedXml.LoadXml(sig);
    
        return signedXml.CheckSignature(cert, true);
    }
