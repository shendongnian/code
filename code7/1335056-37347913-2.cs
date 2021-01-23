        using System;
        using System.IO;
        using System.Net;
        using System.Security.Cryptography.X509Certificates;
        using System.Security.Cryptography.Xml;
        using System.ServiceModel;
        using System.ServiceModel.Channels;
        using System.Text;
        using System.Xml;
        using IrsAcaClient.ACABulkRequestTransmitterService;
    
        namespace IrsAcaClient
        {
        public class General
        {
            /*****************************************************
             * 
             * What I'm doing here (with static vars) is VERY BAD but this whole thing is just a dirty hack for now.
             * Hopefully I can clean this up later.
             * - JRS 2016-05-10
             * 
             *****************************************************/
            public const string SecurityTimestampStringFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffZ";
    
            public const string EnvelopeContentID = "<rootpart>";
    
            public static string AttachmentFilePath;
    
            public static string AttachmentFileName { get { return Path.GetFileName(General.AttachmentFilePath); } }
            public static string AttachmentContentID {get { return string.Format("<{0}>", General.AttachmentFileName); }}
    
            public const string MIMEBoundary = "MIME_boundary";
    
            public static string TCCode;
    
            public static Guid TransmissionGuid;
    
            public static string UniqueTransmissionId
            {
                get { return string.Format("{0}:SYS12:{1}::T", TransmissionGuid, TCCode); }
            }
    
            public static string SecurityTimeStampWsuId;
            public static string ManifestWsuId;
            public static string BusinessHeaderWsuId;
            public static string SignatureWsuId;
    
            public static string CertificatePath;
            public static string CertificatePassword;
    
            public static DateTime SecurityTimestampUTC;
            
            private static string _replacementSoapEnvelope;
    
            public static string ReplacementSoapEnvelope{get { return _replacementSoapEnvelope; }}
    
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
    
            public static string GetAttachmentFileContent()
            {
                //probably not ideal
                return File.ReadAllText(AttachmentFilePath);
            }
    
            public static string GetFileName()
            {
                //TODO: this may need to be tweaked slightly from the real filename
                return General.AttachmentFileName;
            }
    
            public static string GenerateWsuId(string prefix)
            {
                return string.Format("{0}-{1}", prefix, Guid.NewGuid().ToString().Replace("-", "").ToUpper());
            }
    
            internal static void GenerateReplacementSoapEnvelope(ACABulkRequestTransmitterService.SecurityHeaderType securityHeader, ACABulkRequestTransmitterService.ACABulkBusinessHeaderRequestType businessHeader, ACABulkRequestTransmitterService.ACATrnsmtManifestReqDtlType manifest, ACABulkRequestTransmitterService.ACABulkRequestTransmitterType bulkTrans)
            {
                //load the base envelope xml
                var doc = new XmlDocument();
                doc.PreserveWhitespace = false;
                doc.Load("BaseSoapEnvelope.xml");
    
                /* Need a bunch of namespaces defined
                 * xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/"
                 * xmlns:urn="urn:us:gov:treasury:irs:ext:aca:air:7.0"
                 * xmlns:urn1="urn:us:gov:treasury:irs:common"
                 * xmlns:urn2="urn:us:gov:treasury:irs:msg:acabusinessheader"
                 * xmlns:urn3="urn:us:gov:treasury:irs:msg:irsacabulkrequesttransmitter"
                 * xmlns:wsa="http://www.w3.org/2005/08/addressing"
                 * xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"
                 * xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"
                 * xmlns:ds="http://www.w3.org/2000/09/xmldsig#"
                 * xmlns:xop="http://www.w3.org/2004/08/xop/include"
                 */
                XmlNamespaceManager nsMgr = new XmlNamespaceManager(doc.NameTable);
                nsMgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
                nsMgr.AddNamespace("urn", "urn:us:gov:treasury:irs:ext:aca:air:7.0");
                nsMgr.AddNamespace("urn1", "urn:us:gov:treasury:irs:common");
                nsMgr.AddNamespace("urn2", "urn:us:gov:treasury:irs:msg:acabusinessheader");
                nsMgr.AddNamespace("urn3", "urn:us:gov:treasury:irs:msg:irsacabulkrequesttransmitter");
                nsMgr.AddNamespace("wsa", "http://www.w3.org/2005/08/addressing");
                nsMgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                nsMgr.AddNamespace("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");
                nsMgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
                nsMgr.AddNamespace("xop","http://www.w3.org/2004/08/xop/include");
    
    
                //start replacing values in it
                //for securityHeader, should have the following
                /*
                 * securityHeader.Signature.Id
                 * securityHeader.Timestamp.Id
                 * securityHeader.Timestamp.Created.Value
                 * securityHeader.Timestamp.Expires.Value
                 */
                //doc.SelectSingleNode("//wsse:Security/ds:Signature", nsMgr).Attributes["Id"].Value = securityHeader.Signature.Id;
                doc.SelectSingleNode("//wsse:Security/wsu:Timestamp", nsMgr).Attributes["wsu:Id"].Value = securityHeader.Timestamp.Id;
                doc.SelectSingleNode("//wsse:Security/wsu:Timestamp/wsu:Created", nsMgr).InnerText = securityHeader.Timestamp.Created.Value;
                doc.SelectSingleNode("//wsse:Security/wsu:Timestamp/wsu:Expires", nsMgr).InnerText = securityHeader.Timestamp.Expires.Value;
    
    
                //for businessHeader, should have the following
                /*
                 * businessHeader.UniqueTransmissionId
                 * businessHeader.Timestamp
                 * businessHeader.Id 
                 */
                doc.SelectSingleNode("//urn2:ACABusinessHeader", nsMgr).Attributes["wsu:Id"].Value = businessHeader.Id;
                doc.SelectSingleNode("//urn2:ACABusinessHeader/urn:UniqueTransmissionId", nsMgr).InnerText = businessHeader.UniqueTransmissionId;
                doc.SelectSingleNode("//urn2:ACABusinessHeader/urn1:Timestamp", nsMgr).InnerText = businessHeader.Timestamp.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ");
    
    
                //for manifest, should have the following, some of which will need some conversions
                /*
                 * manifest.Id
                 * manifest.BinaryFormatCd - convert from enum
                 * manifest.PaymentYr
                 * manifest.PriorYearDataInd - convert from enum
                 * manifest.EIN
                 * manifest.TransmissionTypeCd - convert from enum
                 * manifest.TestFileCd
                 * manifest.TransmitterNameGrp.BusinessNameLine1Txt
                 * manifest.CompanyInformationGrp.CompanyNm
                 * manifest.CompanyInformationGrp.MailingAddressGrp.Item.AddressLine1Txt
                 * manifest.CompanyInformationGrp.MailingAddressGrp.Item.CityNm
                 * manifest.CompanyInformationGrp.MailingAddressGrp.Item.USStateCd - convert from enum
                 * manifest.CompanyInformationGrp.MailingAddressGrp.Item.USZIPCd
                 * manifest.CompanyInformationGrp.ContactNameGrp.PersonFirstNm
                 * manifest.CompanyInformationGrp.ContactNameGrp.PersonLastNm
                 * manifest.CompanyInformationGrp.ContactPhoneNum
                 * manifest.VendorInformationGrp.VendorCd
                 * manifest.VendorInformationGrp.ContactNameGrp.PersonFirstNm
                 * manifest.VendorInformationGrp.ContactNameGrp.PersonLastNm
                 * manifest.VendorInformationGrp.ContactPhoneNum
                 * manifest.TotalPayeeRecordCnt
                 * manifest.TotalPayerRecordCnt
                 * manifest.SoftwareId
                 * manifest.FormTypeCd - convert from enum
                 * manifest.ChecksumAugmentationNum
                 * manifest.AttachmentByteSizeNum
                 * manifest.DocumentSystemFileNm
                 */
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl", nsMgr).Attributes["wsu:Id"].Value = manifest.Id;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:PaymentYr", nsMgr).InnerText = manifest.PaymentYr;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:PriorYearDataInd", nsMgr).InnerText = manifest.PriorYearDataInd.GetXmlEnumAttributeValueFromEnum();
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn1:EIN", nsMgr).InnerText = manifest.EIN;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:TransmissionTypeCd", nsMgr).InnerText = manifest.TransmissionTypeCd.ToString();
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:TestFileCd", nsMgr).InnerText = manifest.TestFileCd;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:TransmitterNameGrp/urn:BusinessNameLine1Txt", nsMgr).InnerText = manifest.TransmitterNameGrp.BusinessNameLine1Txt;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:CompanyNm", nsMgr).InnerText = manifest.CompanyInformationGrp.CompanyNm;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:MailingAddressGrp/urn:USAddressGrp/urn:AddressLine1Txt", nsMgr).InnerText = ((USAddressGrpType)manifest.CompanyInformationGrp.MailingAddressGrp.Item).AddressLine1Txt;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:MailingAddressGrp/urn:USAddressGrp/urn1:CityNm", nsMgr).InnerText = ((USAddressGrpType)manifest.CompanyInformationGrp.MailingAddressGrp.Item).CityNm;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:MailingAddressGrp/urn:USAddressGrp/urn:USStateCd", nsMgr).InnerText = ((USAddressGrpType)manifest.CompanyInformationGrp.MailingAddressGrp.Item).USStateCd.ToString();
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:MailingAddressGrp/urn:USAddressGrp/urn1:USZIPCd", nsMgr).InnerText = ((USAddressGrpType)manifest.CompanyInformationGrp.MailingAddressGrp.Item).USZIPCd;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:ContactNameGrp/urn:PersonFirstNm", nsMgr).InnerText = manifest.CompanyInformationGrp.ContactNameGrp.PersonFirstNm;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:ContactNameGrp/urn:PersonLastNm", nsMgr).InnerText = manifest.CompanyInformationGrp.ContactNameGrp.PersonLastNm;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:CompanyInformationGrp/urn:ContactPhoneNum", nsMgr).InnerText = manifest.CompanyInformationGrp.ContactPhoneNum;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:VendorInformationGrp/urn:VendorCd", nsMgr).InnerText = manifest.VendorInformationGrp.VendorCd;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:VendorInformationGrp/urn:ContactNameGrp/urn:PersonFirstNm", nsMgr).InnerText = manifest.VendorInformationGrp.ContactNameGrp.PersonFirstNm;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:VendorInformationGrp/urn:ContactNameGrp/urn:PersonLastNm", nsMgr).InnerText = manifest.VendorInformationGrp.ContactNameGrp.PersonLastNm;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:VendorInformationGrp/urn:ContactPhoneNum", nsMgr).InnerText = manifest.VendorInformationGrp.ContactPhoneNum;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:TotalPayeeRecordCnt", nsMgr).InnerText = manifest.TotalPayeeRecordCnt;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:TotalPayerRecordCnt", nsMgr).InnerText = manifest.TotalPayerRecordCnt;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:SoftwareId", nsMgr).InnerText = manifest.SoftwareId;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:FormTypeCd", nsMgr).InnerText = manifest.FormTypeCd.GetXmlEnumAttributeValueFromEnum();
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn1:BinaryFormatCd", nsMgr).InnerText = manifest.BinaryFormatCd.GetXmlEnumAttributeValueFromEnum();
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn1:ChecksumAugmentationNum", nsMgr).InnerText = manifest.ChecksumAugmentationNum;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn1:AttachmentByteSizeNum", nsMgr).InnerText = manifest.AttachmentByteSizeNum;
                doc.SelectSingleNode("//urn:ACATransmitterManifestReqDtl/urn:DocumentSystemFileNm", nsMgr).InnerText = manifest.DocumentSystemFileNm;
    
    
                //for bulkTrans, should have the following
                /*
                 * bulkTrans.BulkExchangeFile.Include.href
                 */
                doc.SelectSingleNode("//urn3:ACABulkRequestTransmitter/urn1:BulkExchangeFile/xop:Include", nsMgr).Attributes["href"].Value = bulkTrans.BulkExchangeFile.Include.href;
    
    
                //now do some more security setup
                var cert = new X509Certificate2(CertificatePath, CertificatePassword, X509KeyStorageFlags.MachineKeySet);
    
                var exported = cert.Export(X509ContentType.Cert, CertificatePassword);
                var base64 = Convert.ToBase64String(exported);
    
                //now compute all the signing stuff
                var xSigned = new SignedXmlWithId(doc);
                xSigned.Signature.Id = securityHeader.Signature.Id;
    
                // Add the key to the SignedXml document.
                xSigned.SigningKey = cert.PrivateKey;
                xSigned.Signature.Id = SignatureWsuId;
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
    
                GenerateReference(SecurityTimeStampWsuId, "wsse wsa soapenv urn urn1 urn2 urn3", xSigned);
                GenerateReference(BusinessHeaderWsuId, "wsa soapenv urn urn1 urn3", xSigned);
                GenerateReference(ManifestWsuId, "wsa soapenv urn1 urn2 urn3", xSigned);
    
                // Compute the Signature.
                xSigned.ComputeSignature();
    
                //signing stuff must come before the timestamp or the IRS service complains
                doc.SelectSingleNode("//wsse:Security", nsMgr).InsertBefore(xSigned.GetXml(), doc.SelectSingleNode("//wsse:Security", nsMgr).FirstChild);
    
                //
                _replacementSoapEnvelope = doc.OuterXml;
            }
    
            public static ACABulkRequestTransmitterResponseType Run(ACABulkRequestTransmitterService.SecurityHeaderType securityHeader, ACABulkRequestTransmitterService.ACABulkBusinessHeaderRequestType businessHeader, ACABulkRequestTransmitterService.ACATrnsmtManifestReqDtlType manifest, ACABulkRequestTransmitterService.ACABulkRequestTransmitterType bulkTrans)
            {
                //had some issues early on with the cert on the IRS server, this should probably be removed and retested without it
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 |
                                                       SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
    
                var acaSecurityHeader = new ACABulkRequestTransmitterService.TransmitterACASecurityHeaderType(); //leave this empty for transmitting via ISS-A2A
    
                var requestClient = new ACABulkRequestTransmitterService.BulkRequestTransmitterPortTypeClient("BulkRequestTransmitterPort");
    
                requestClient.Endpoint.Contract.ProtectionLevel = System.Net.Security.ProtectionLevel.None;
                //var vs = requestClient.Endpoint.Behaviors.Where((i) => i.GetType().Namespace.Contains("VisualStudio"));
                //if (vs != null)
                //    requestClient.Endpoint.Behaviors.Remove((System.ServiceModel.Description.IEndpointBehavior)vs.Single());
    
                //generate the real envelope we want
                GenerateReplacementSoapEnvelope(securityHeader, businessHeader, manifest, bulkTrans);
    
                using (var scope = new OperationContextScope(requestClient.InnerChannel))
                {
    
                    //Adding proper HTTP Header to an outgoing requqest.
                    HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
    
                    requestMessage.Headers["Content-Encoding"] = "gzip";
                    requestMessage.Headers["Content-Type"] = string.Format(@"multipart/related; type=""application/xop+xml"";start=""{0}"";start-info=""text/xml"";boundary=""{1}""", General.EnvelopeContentID, General.MIMEBoundary);
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
    
                    var response = requestClient.BulkRequestTransmitter(acaSecurityHeader,
                                                                        securityHeader,
                                                                        ref businessHeader,
                                                                        manifest,
                                                                        bulkTrans);
    
                    //we got a response!  now do something with it
                    return response;
    
                }
            }
        }
