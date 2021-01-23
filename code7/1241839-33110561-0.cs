		var parsedSoap = XElement.Parse(soapMessage);
		XNamespace  payPalResponseNs ="urn:ebay:api:PayPalAPI";
		XNamespace resultingResponseNs = "urn:ebay:apis:eBLBaseComponents";
		parsedSoap.Descendants()
				  .Where(x=> x.Name == payPalResponseNs+"SetExpressCheckoutResponse")
				  .Select(x=> new 
						{
							Timestamp = x.Element(resultingResponseNs +"Timestamp")?.Value,
							Ack = x.Element(resultingResponseNs +"Ack")?.Value,
							CorrelationID = x.Element(resultingResponseNs +"CorrelationID")?.Value,
							Version = x.Element(resultingResponseNs +"Version")?.Value,
							Build = x.Element(resultingResponseNs +"Build")?.Value,
							Token = x.Element(payPalResponseNs +"Token")?.Value
						}
						);
