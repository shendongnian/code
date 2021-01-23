           var requestClient = new BulkRequestTransmitterPortTypeClient("BulkRequestTransmitterPort");
                requestClient.Endpoint.Contract.ProtectionLevel = System.Net.Security.ProtectionLevel.None;
         #if DEBUG
                var vs = requestClient.Endpoint.Behaviors.Where((i) => i.GetType().Namespace.Contains("VisualStudio"));
                if( vs!=null )
                 requestClient.Endpoint.Behaviors.Remove((System.ServiceModel.Description.IEndpointBehavior)vs.Single());
        #endif                
           using (var scope = new OperationContextScope(requestClient.InnerChannel))
                {
                     //Adding proper HTTP Header to an outgoing requqest.
                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Content-Encoding"] = "gzip";
                    requestMessage.Headers["Content-Type"] = @"multipart/related; type=""application/xop+xml"";start=""<Here goes envelope boundary id>"";start-info=""text/xml"";boundary=""here goes boundary id""";
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                    response = requestClient.BulkRequestTransmitter(request.ACASecurityHeader,
                                                                        request.Security, ref request.ACABusinessHeader,
                                                                        request.ACATransmitterManifestReqDtl, 
                                                                        request.ACABulkRequestTransmitter);
                }
