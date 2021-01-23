    foreach (XmlElement node in xmlDoc.SelectNodes("//*[local-name()='Signature']"))
    {// Verify this Signature block
        SignedXml signedXml = new SignedXml(node.ParentNode as XmlElement);
        signedXml.LoadXml(node);
        KeyInfoX509Data x509Data = signedXml.Signature.KeyInfo.OfType<KeyInfoX509Data>().First();
        // *** BEGIN: ADDED CODE ***
        if (!node.ParentNode.Equals(node.OwnerDocument.DocumentElement))
		{
			node.ParentNode.RemoveChild(node);
            // This line ^^^ is apparently optional, but it makes me feel better
			node.OwnerDocument.DocumentElement.AppendChild(node);
		}
        // *** END: ADDED CODE ***
        // Verify certificate
        ...
