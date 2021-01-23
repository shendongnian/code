    var samlToken = (SecurityToken)null;
    var form = await Request.ReadFormAsync(); // I am using IOwinRequest here.
    if (form.Count() > 0)
    {
    	var samlResponses = form.GetValues("SAMLResponse");
    	if (samlResponses != null && samlResponses.Count > 0)
    	{
    		foreach (var samlResponse in samlResponses)
    		{
    			try
    			{
    				var decodedSamlResponse = Convert.FromBase64String(samlResponse);
    				var reader = XmlReader.Create(new MemoryStream(decodedSamlResponse));
    				var serializer = new XmlSerializer(typeof(XmlElement));
    				var samlResponseElement = (XmlElement)serializer.Deserialize(reader);
    				var manager = new XmlNamespaceManager(samlResponseElement.OwnerDocument.NameTable);
    				manager.AddNamespace("saml2", "urn:oasis:names:tc:SAML:2.0:assertion");
    				var assertion = (XmlElement)samlResponseElement.SelectSingleNode("//saml2:Assertion", manager);
    				samlToken = (Saml2SecurityToken)Options.SecurityTokenHandlers.ReadToken(XmlReader.Create(new StringReader(assertion.OuterXml)));
    				break;
    			}
    			catch { }
    		}
    	}
    }
