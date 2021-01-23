                    var soapResponse = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>")
                                       .Append("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">")
                                       .Append("<soap:Body>")
                                       .Append("<WebMethodResponse xmlns=\"http://tempuri.org/\">")
                                       .Append(String.Format("<WebMethodResult>{0}</WebMethodResult>",HttpUtility.HtmlEncode(webApiResponse)))
                                       .Append("</WebMethodResponse>")
                                       .Append("</soap:Body>")
                                       .Append("</soap:Envelope>");
                                       
                    context.Response.ContentType = "text/xml";
                    context.Response.Write(soapResponse);
                    context.Response.End();
