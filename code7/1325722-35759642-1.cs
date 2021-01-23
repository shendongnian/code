    // Create a new XML Document.
    XmlDocument xdoc = new XmlDocument();
 
    xdoc.PreserveWhitespace = true;
    // Load the passed XML File using its name.
    xdoc.Load(new XmlTextReader(fileName));
    // Create a SignedXml Object.
    //SignedXml xSigned = new SignedXml(xdoc);
    SignedXmlWithId xSigned = new SignedXmlWithId(xdoc); // Use this class instead of the SignedXml class above.
    // Add the key to the SignedXml document.
    xSigned.SigningKey = cert.PrivateKey;
    xSigned.Signature.Id = SignatureID;
    xSigned.SignedInfo.CanonicalizationMethod = 
            SignedXml.XmlDsigExcC14NWithCommentsTransformUrl;
    //Initialize a variable to contain the ID of the Timestamp element.
    string elementId = TimestampID;
    Reference reference = new Reference()
    {
        Uri = "#" + elementId
    };
    XmlDsigExcC14NTransform env = new XmlDsigExcC14NTransform();
    env.InclusiveNamespacesPrefixList = _includedPrefixList;
    reference.AddTransform(env);
    xSigned.AddReference(reference);
    // Add Key Information (omitted)
    // Compute Signature
    xSigned.ComputeSignature();
