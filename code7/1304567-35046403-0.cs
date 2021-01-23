        public string TestGPConnection()
        {
            try
            {                
               using (eConnectMethods requester = new eConnectMethods())
               {
                // Create an eConnect document type object
                eConnectType myEConnectType = new eConnectType();
                // Create a RQeConnectOutType schema object
                RQeConnectOutType myReqType = new RQeConnectOutType();
                // Create an eConnectOut XML node object
                eConnectOut myeConnectOut = new eConnectOut();
                // Populate the eConnectOut XML node elements
                myeConnectOut.ACTION = 1;
                myeConnectOut.DOCTYPE = "GL_Accounts";
                myeConnectOut.OUTPUTTYPE = 2;
                myeConnectOut.FORLIST = 1;
                myeConnectOut.WhereClause = "(ACTNUMST = '99-9999-99-999')";
                // Add the eConnectOut XML node object to the RQeConnectOutType schema object
                myReqType.eConnectOut = myeConnectOut;
                // Add the RQeConnectOutType schema object to the eConnect document object
                RQeConnectOutType[] myReqOutType = { myReqType };
                myEConnectType.RQeConnectOutType = myReqOutType;
                // Serialize the eConnect document object to a memory stream
                MemoryStream myMemStream = new MemoryStream();
                XmlSerializer mySerializer = new XmlSerializer(myEConnectType.GetType());
                mySerializer.Serialize(myMemStream, myEConnectType);
                myMemStream.Position = 0;
                // Load the serialized eConnect document object into an XML document object
                XmlTextReader xmlreader = new XmlTextReader(myMemStream);
                XmlDocument myXmlDocument = new XmlDocument();
                myXmlDocument.Load(xmlreader);
                var tokenSource = new CancellationTokenSource();
                CancellationToken token = tokenSource.Token;
                int timeOut = 20000; //20 seconds
                try
                {
                    string reqDoc = requester.GetEntity(GPCongfigSettings.GPConnectionString, myXmlDocument.OuterXml);
                }
                catch (CommunicationObjectFaultedException cofe)
                {
                    return "Communication Exception - " + cofe.Message;
                }
                //connection string is correct
                return "Correct Connection";
                }
            }
            catch (FaultException fe)
            {
                return "Fault Exception - " + fe.Message;
            }
            catch (eConnectException exc)
            {
                Console.WriteLine(exc.Message);
                return "eConnect Exception - " + exc.Message;
            }            
            catch (CommunicationObjectFaultedException cofe)
            {
                return "Communication Exception - " + cofe.Message;
            }
            catch (Exception ex)
            {
                return "Exception - " + ex.Message;
            }
            //finally
            //{
            //    // Release the resources of the eConnectMethods object
            //    requester.Dispose();
            //}
        }
