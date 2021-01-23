    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace IrsAcaClient
    {
        public class StatusService
        {
            private const string SecurityTimestampStringFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffZ";
    
    
            public static ACABulkRequestStatusService.ACABulkRequestTransmitterStatusDetailResponseType CheckStatus(string receiptID, string tCCode, string certificatePath, string certificatePassword, string statusServiceUrl)
            {
                //go ahead and generate some of the ids and timestamps we'll need
                var securityTimeStampWsuId = GenerateWsuId("TS");
                var businessHeaderWsuId = GenerateWsuId("id");
                var detailRequestWsuId = GenerateWsuId("id");
                var signatureWsuId = GenerateWsuId("SIG");
    
                var securityTimestampUTC = DateTime.UtcNow;
                var securityTimestampCreated = securityTimestampUTC.ToString(SecurityTimestampStringFormat);
                var securityTimestampExpires = securityTimestampUTC.AddMinutes(10).ToString(SecurityTimestampStringFormat);
    
                //build the envelope
                //load the base envelope xml
                var doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.Load("BaseStatusRequestEnvelope.xml");
    
                /* Need a bunch of namespaces defined
                 * xmlns:oas1="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"
                 * xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
                 * xmlns:urn="urn:us:gov:treasury:irs:msg:irstransmitterstatusrequest"
                 * xmlns:urn1="urn:us:gov:treasury:irs:ext:aca:air:7.0" 
                 * xmlns:urn2="urn:us:gov:treasury:irs:common"
                 * xmlns:urn3="urn:us:gov:treasury:irs:msg:acasecurityheader"
                 * xmlns:wsa="http://www.w3.org/2005/08/addressing"
                 * xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" 
                 * xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"
                 * xmlns:ds="http://www.w3.org/2000/09/xmldsig#");
                 */
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
                nsMgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                nsMgr.AddNamespace("urn", "urn:us:gov:treasury:irs:msg:irstransmitterstatusrequest");
                nsMgr.AddNamespace("urn1", "urn:us:gov:treasury:irs:ext:aca:air:7.0");
                nsMgr.AddNamespace("urn2", "urn:us:gov:treasury:irs:common");
                nsMgr.AddNamespace("urn3", "urn:us:gov:treasury:irs:msg:acasecurityheader");
                nsMgr.AddNamespace("wsa", "http://www.w3.org/2005/08/addressing");
                nsMgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                nsMgr.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
                nsMgr.AddNamespace("oas1", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                nsMgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
    
                //start replacing values in it
                //for securityHeader, should have the following
                /*
                 * securityHeader.Timestamp.Id
                 * securityHeader.Timestamp.Created.Value
                 * securityHeader.Timestamp.Expires.Value
                 */
                doc.SelectSingleNode("//wsse:Security/wsu:Timestamp", nsMgr).Attributes["wsu:Id"].Value = securityTimeStampWsuId;
                doc.SelectSingleNode("//wsse:Security/wsu:Timestamp/wsu:Created", nsMgr).InnerText = securityTimestampCreated;
                doc.SelectSingleNode("//wsse:Security/wsu:Timestamp/wsu:Expires", nsMgr).InnerText = securityTimestampExpires;
    
                //for businessHeader, should have the following
                /*
                 * businessHeader.UniqueTransmissionId
                 * businessHeader.Timestamp
                 * businessHeader.Id 
                 */
                doc.SelectSingleNode("//urn:ACABusinessHeader", nsMgr).Attributes["wsu:Id"].Value = businessHeaderWsuId;
                doc.SelectSingleNode("//urn:ACABusinessHeader/urn1:UniqueTransmissionId", nsMgr).InnerText = GetUniqueTransmissionId(Guid.NewGuid(), tCCode);
                doc.SelectSingleNode("//urn:ACABusinessHeader/urn2:Timestamp", nsMgr).InnerText = securityTimestampUTC.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ");
    
                //for ACABulkRequestTransmitterStatusDetailRequest, should have the following
                /*
                 * ACABulkRequestTransmitterStatusDetailRequest.Id
                 * ACABulkRequestTransmitterStatusDetailRequest.ACABulkReqTrnsmtStsReqGrpDtl.ReceiptId
                 */
                doc.SelectSingleNode("//urn:ACABulkRequestTransmitterStatusDetailRequest", nsMgr).Attributes["wsu:Id"].Value = detailRequestWsuId;
                doc.SelectSingleNode("//urn:ACABulkRequestTransmitterStatusDetailRequest/urn1:ACABulkReqTrnsmtStsReqGrpDtl/urn2:ReceiptId", nsMgr).InnerText = receiptID;
    
                //now do some more security setup
                var cert = new X509Certificate2(certificatePath, certificatePassword, X509KeyStorageFlags.MachineKeySet);
    
                var exported = cert.Export(X509ContentType.Cert, certificatePassword);
                var base64 = Convert.ToBase64String(exported);
    
                //now compute all the signing stuff
                var xSigned = new SignedXmlWithId(doc);
    
                // Add the key to the SignedXml document.
                xSigned.SigningKey = cert.PrivateKey;
                xSigned.Signature.Id = signatureWsuId;
                xSigned.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NWithCommentsTransformUrl;
    
                var keyInfo = new KeyInfo
                {
                    Id = GenerateWsuId("KI")
                };
    
                //need to get the keyinfo into the signed xml stuff before we compute sigs, and because it is using some stuff that
                //doesn't appear to be supported out of the box we'll work around it by adding a node directly
                var sbKeyInfo = new StringBuilder();
                sbKeyInfo.Append("<root xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\">");
                sbKeyInfo.Append("<wsse:SecurityTokenReference wsu:Id=\"" + GenerateWsuId("STR") + "\">");
                sbKeyInfo.Append("<wsse:KeyIdentifier EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\" ValueType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509v3\">" + base64.ToString());
                sbKeyInfo.Append("</wsse:KeyIdentifier>");
                sbKeyInfo.Append("</wsse:SecurityTokenReference>");
                sbKeyInfo.Append("</root>");
                XmlDocument tempDoc = new XmlDocument();
                tempDoc.LoadXml(sbKeyInfo.ToString());
    
                keyInfo.AddClause(new KeyInfoNode((XmlElement)tempDoc.FirstChild.FirstChild));
    
                xSigned.KeyInfo = keyInfo;
    
                GenerateReference(securityTimeStampWsuId, "wsse wsa oas1 soapenv urn urn1 urn2 urn3", xSigned);
                GenerateReference(businessHeaderWsuId, "wsa oas1 soapenv urn1 urn2 urn3", xSigned);
                GenerateReference(detailRequestWsuId, "oas1 soapenv urn1 urn2 urn3", xSigned);
    
                // Compute the Signature.
                xSigned.ComputeSignature();
    
                //signing stuff must come before the timestamp or the IRS service complains
                doc.SelectSingleNode("//wsse:Security", nsMgr).InsertBefore(xSigned.GetXml(), doc.SelectSingleNode("//wsse:Security", nsMgr).FirstChild);
    
                //get the completed envelope
                var envelope = doc.OuterXml;
    
                //start the webrequest
                //get the request object
                var request = CreateWebRequest(statusServiceUrl);
    
                //get the request stream and then get a writer on it
                using (var stream = request.GetRequestStream())
                using (var gz = new GZipStream(stream, CompressionMode.Compress))
                using (var writer = new StreamWriter(gz))
                {
                    //start by writing the soap envelope to the stream
                    writer.WriteLine(envelope);
                    writer.Close();
                    stream.Close();
                }
    
                //get the response
                WebResponse response;
                
                //let an exception get thrown up the stack
                response = request.GetResponse();
    
                //get the response stream, get a reader on it, and read the response as text
                using (var responseStream = response.GetResponseStream())
                using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    var responseText = reader.ReadToEnd();
    
                    //rip the one element (and children) we need out
                    var match = Regex.Match(responseText, @"<(?'prefix'[\w\d]*):ACABulkRequestTransmitterStatusDetailResponse.*<\/\k<prefix>:ACABulkRequestTransmitterStatusDetailResponse>");
    
                    return Deserialize<ACABulkRequestStatusService.ACABulkRequestTransmitterStatusDetailResponseType>(match.ToString());
                }
            }
    
            private static string GetUniqueTransmissionId(Guid transmissionGuid, string tCCode)
            {
                return string.Format("{0}:SYS12:{1}::T", transmissionGuid, tCCode);
            }
    
            private static string GenerateWsuId(string prefix)
            {
                return string.Format("{0}-{1}", prefix, Guid.NewGuid().ToString().Replace("-", "").ToUpper());
            }
    
            private static void GenerateReference(string elementID, string inclusivePrefixList, SignedXmlWithId xSigned)
            {
                var reference = new Reference()
                {
                    Uri = "#" + elementID
                };
    
                XmlDsigExcC14NTransform env = new XmlDsigExcC14NTransform();
                env.InclusiveNamespacesPrefixList = inclusivePrefixList;
                reference.AddTransform(env);
    
                xSigned.AddReference(reference);
            }
    
            /// <summary>
            /// creates a webrequest object and prefills some required headers and such
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            private static HttpWebRequest CreateWebRequest(string url)
            {
                //setup a web request with all the headers and such that the service requires
                var webRequest = (HttpWebRequest)WebRequest.Create(url);
    
                webRequest.Method = "POST";
                webRequest.ProtocolVersion = HttpVersion.Version11;
                webRequest.Headers.Add(HttpRequestHeader.ContentEncoding, "gzip");
                webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                webRequest.ContentType = "text/xml;charset=UTF-8";
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                webRequest.Headers.Add("SOAPAction", "RequestSubmissionStatusDetail");
                webRequest.KeepAlive = true;
    
                return webRequest;
            }
    
            /// <summary>
            /// deserializes the xml string into an object
            /// </summary>
            /// <param name="xmlString"></param>
            /// <returns></returns>
            public static T Deserialize<T>(string xmlString) where T : class
            {
                //if the string is empty, just return null
                if (xmlString.Length <= 0)
                {
                    return null;
                }
    
                //create a serializer
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                T output;
                //create the reader that the serializer will read from, passing it the string
                using (var reader = new System.IO.StringReader(xmlString))
                {
                    //rebuild the list object
                    output = (T)serializer.Deserialize(reader);
                }
                //return the list
                return output;
            }
        }
    }
