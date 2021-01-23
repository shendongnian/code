    var binding = new CustomBinding();
    binding.Elements.Add(new CustomMessageEncoderBindingElement());
    var sec = SecurityBindingElement.CreateCertificateOverTransportBindingElement();
    // AllowSerializedSigningTokenOnReply = true
    sec.EnableUnsecuredResponse = true;
    sec.MessageSecurityVersion = MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
    binding.Elements.Add(sec);
    binding.Elements.Add(new HttpsTransportBindingElement() { MaxReceivedMessageSize = 2000000 });
    var endpoint = new EndpointAddress("https://ws.sample.com/DeviceQuery/v1");
    var client = new TestWS.DeviceInfoServiceTypeClient(binding, endpoint);
    client.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser,
                                                          StoreName.My,
                                                          X509FindType.FindByIssuerName,
                                                          "Sample");
