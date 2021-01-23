         public SabreSessionInfo sabreCreateSession(string user, string pass, string pseudo, string iPseudo, bool doGetAirVendors)
                    {
                        SabreSessionInfo inf = new SabreSessionInfo();
            
                        try
                        {
                            userName = user;
                            password = pass;
            
                            iPCC = iPseudo;
                            PCC = pseudo;
            
                            string domain = "DEFAULT";
            
                            DateTime dt = DateTime.UtcNow;
                            string tstamp = dt.ToString("s") + "Z";
            
                            SabreSesh.MessageHeader msgHeader = new SabreSesh.MessageHeader();
            
                            msgHeader.ConversationId = "TestSession";		// Set the ConversationId
            
                            SabreSesh.From from = new SabreSesh.From();
                            SabreSesh.PartyId fromPartyId = new SabreSesh.PartyId();
                            SabreSesh.PartyId[] fromPartyIdArr = new SabreSesh.PartyId[1];
                            fromPartyId.Value = "WebServiceClient";
                            fromPartyIdArr[0] = fromPartyId;
                            from.PartyId = fromPartyIdArr;
                            msgHeader.From = from;
            
                            SabreSesh.To to = new SabreSesh.To();
                            SabreSesh.PartyId toPartyId = new SabreSesh.PartyId();
                            SabreSesh.PartyId[] toPartyIdArr = new SabreSesh.PartyId[1];
                            toPartyId.Value = "WebServiceSupplier";
                            toPartyIdArr[0] = toPartyId;
                            to.PartyId = toPartyIdArr;
                            msgHeader.To = to;
            
                            //Add the value for eb:CPAId, which is the IPCC. 
                            //Add the value for the action code of this Web service, SessionCreateRQ.
            
                            msgHeader.CPAId = iPCC;
                            msgHeader.Action = "SessionCreateRQ";
                            SabreSesh.Service service = new SabreSesh.Service();
                            service.Value = "SessionCreate";
                            msgHeader.Service = service;
            
                            SabreSesh.MessageData msgData = new SabreSesh.MessageData();
                            msgData.MessageId = "mid:20001209-133003-2333@clientofsabre.com1";
                            msgData.Timestamp = tstamp;
                            msgHeader.MessageData = msgData;
            
                            SabreSesh.Security security = new SabreSesh.Security();
                            SabreSesh.SecurityUsernameToken securityUserToken = new SabreSesh.SecurityUsernameToken();
                            securityUserToken.Username = userName;
                            securityUserToken.Password = password;
                            securityUserToken.Organization = iPCC;
                            securityUserToken.Domain = domain;
                            security.UsernameToken = securityUserToken;
                            
                            SabreSesh.SessionCreateRQ req = new SabreSesh.SessionCreateRQ();
                            SabreSesh.SessionCreateRQPOS pos = new SabreSesh.SessionCreateRQPOS();
                            SabreSesh.SessionCreateRQPOSSource source = new SabreSesh.SessionCreateRQPOSSource();
                            source.PseudoCityCode = iPCC;
                            pos.Source = source;
                            req.POS = pos;
            
                            SabreSesh.SessionCreateRQService serviceObj = new SabreSesh.SessionCreateRQService();
                            serviceObj.MessageHeaderValue = msgHeader;
                            serviceObj.SecurityValue = security;
                         
                            
                            lock (lockObject)
                            {
                                
                                SabreSesh.SessionCreateRS resp = new SabreSesh.SessionCreateRS();
                                try
                                {
                                    resp = serviceObj.SessionCreateRQ(req);	// Send the request
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                                }
            
                                
                            }
            
                           
                           
                          
                            
                            inf.conversationID = msgHeader.ConversationId;
                            inf.sabreToken = security.BinarySecurityToken;
              
                                           
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                        }
    
                return inf;
                }
    
     public class SabreSessionInfo
        {
            public string conversationID { get; set;}
            public string sabreToken { get; set; }
    
            public SabreSessionInfo()
            {
                conversationID = "";
                sabreToken = "";
            }
        }
    
           
    
    
