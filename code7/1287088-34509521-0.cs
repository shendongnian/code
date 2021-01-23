    private X509Certificate2 certificate;
    private Config config;
        public RoyalMail() {
            // Load The Config
            config = new Config();
            config.loadConfig();
            // Load The SSL Certificate (Check The File Exists)
            String certificatePath = (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + config.GetCertificateName());
            if (!System.IO.File.Exists(certificatePath))
            {
                throw new Exception(@"The Royal Mail Certificate Is Missing From The Plugins Directory. Please Place The File " + config.GetCertificateName() + " In The Same Directory As The Plugin DLL File & Relaunch FileMaker.\n\n" + certificatePath);
            }
            certificate = new X509Certificate2(certificatePath, config.GetCertificatePassword());
            // Check It's In The Certificate 
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);
            if (!store.Certificates.Contains(certificate))
            {
                store.Add(certificate);
                MessageBox.Show("Certificate Was Installed Into Computer Trust Store");
            }
            store.Close(); 
        }
        /*
         * 
         * SOAP Service & Methods
         * 
         */
        private shippingAPIPortTypeClient GetProxy()
        {
            BasicHttpBinding myBinding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            myBinding.MaxReceivedMessageSize = 2147483647;
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            shippingClient = new shippingAPIPortTypeClient(myBinding, new EndpointAddress(new Uri(config.GetEndpointURL()), EndpointIdentity.CreateDnsIdentity("api.royalmail.com"), new AddressHeaderCollection()));
            shippingClient.ClientCredentials.ClientCertificate.Certificate = certificate;
            foreach (OperationDescription od in shippingClient.Endpoint.Contract.Operations)
            {
                od.Behaviors.Add(new RoyalMailIEndpointBehavior());
            }
            return shippingClient;
        }
        private SecurityHeaderType GetSecurityHeaderType()
        {
            SecurityHeaderType securityHeader = new SecurityHeaderType();
            DateTime created = DateTime.Now;
            string creationDate;
            creationDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string nonce = nonce = (new Random().Next(0, int.MaxValue)).ToString();
            byte[] hashedPassword;
            hashedPassword = GetSHA1(config.GetPassword());
            string concatednatedDigestInput = string.Concat(nonce, creationDate, Encoding.Default.GetString(hashedPassword));
            byte[] digest;
            digest = GetSHA1(concatednatedDigestInput);
            string passwordDigest;
            passwordDigest = Convert.ToBase64String(digest);
            string encodedNonce;
            encodedNonce = Convert.ToBase64String(Encoding.Default.GetBytes(nonce));
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Security");
                writer.WriteStartElement("UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
                writer.WriteElementString("Username", config.GetUsername());
                writer.WriteElementString("Password", passwordDigest);
                writer.WriteElementString("Nonce", encodedNonce);
                writer.WriteElementString("Created", creationDate);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
            doc.DocumentElement.RemoveAllAttributes();
            System.Xml.XmlElement[] headers = doc.DocumentElement.ChildNodes.Cast<XmlElement>().ToArray<XmlElement>();
            securityHeader.Any = headers;
            return securityHeader;
        }
        private integrationHeader GetIntegrationHeader()
        {
            integrationHeader header = new integrationHeader();
            DateTime created = DateTime.Now;
            String createdAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            header.dateTime = created;
            header.version = Int32.Parse(config.GetVersion());
            header.dateTimeSpecified = true;
            header.versionSpecified = true;
            identificationStructure idStructure = new identificationStructure();
            idStructure.applicationId = config.GetApplicationID();
            string nonce = nonce = (new Random().Next(0, int.MaxValue)).ToString();
            idStructure.transactionId = CalculateMD5Hash(nonce + createdAt);
            header.identification = idStructure;
            return header;
        }
        private static byte[] GetSHA1(string input)
        {
            return SHA1Managed.Create().ComputeHash(Encoding.Default.GetBytes(input));
        }
        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        
        /*
         * Check Response Footer For Errors & Warnings From Service
         * If Error Return True So We Can Inform Filemaker Of Error
         * Ignore Warnings For Now
         * 
         */
        private bool checkErrorsAndWarnings(integrationFooter integrationFooter)
        {
            if (integrationFooter != null)
            {
                if (integrationFooter.errors != null && integrationFooter.errors.Length > 0)
                {
                    errorDetail[] errors = integrationFooter.errors;
                    for (int i = 0; i < errors.Length; i++)
                    {
                        errorDetail error = errors[i];
                        MessageBox.Show("Royal Mail Request Error: " + error.errorDescription + ". " + error.errorResolution, "Royal Mail Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                    if (errors.Length > 0)
                    {
                        return true;
                    }
                }
                if (integrationFooter.warnings != null && integrationFooter.warnings.Length > 0)
                {
                    warningDetail[] warnings = integrationFooter.warnings;
                    for (int i = 0; i < warnings.Length; i++)
                    {
                        warningDetail warning = warnings[i];
                        //MessageBox.Show("Royal Mail Request Warning: " + warning.warningDescription + ". " + warning.warningResolution, "Royal Mail Request Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            return false;
        }
        /*
         * Show Message Box With SOAP Error If We Receive A Fault Code Back From Service
         *
         */
        private void showSoapException(FaultException e)
        {
            MessageFault message = e.CreateMessageFault();
            
            XmlElement errorDetail = message.GetDetail<XmlElement>();
            XmlNodeList errorDetails = errorDetail.ChildNodes;
            String fullErrorDetails = "";
            for (int i = 0; i < errorDetails.Count; i++)
            {
                fullErrorDetails += errorDetails.Item(i).Name + ": " + errorDetails.Item(i).InnerText + "\n";
            }
            MessageBox.Show("An Error Occured With Royal Mail Service: " + message.Reason.ToString() + "\n\n" + fullErrorDetails, "Royal Mail SOAP Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        public createShipmentResponse SendCreateShipmentRequest(CreateShipmentForm shippingForm)
        {
            shippingAPIPortTypeClient client = GetProxy();
            try
            {
                createShipmentRequest request = new createShipmentRequest();
                request.integrationHeader = GetIntegrationHeader();
                requestedShipment shipment = new requestedShipment();
                // Shipment Type Code (Delivery or Return)
                referenceDataType shipmentType = new referenceDataType();
                shipmentType.code = shippingForm.GetShippingType();
                shipment.shipmentType = shipmentType;
                // Service Occurence (Identifies Agreement on Customers Account) Default to 1. Not Required If There Is There Is Only 1 On Account
                shipment.serviceOccurrence = config.GetServiceOccurance();
                // Service Type Code (1:24H 1st Class, 2: 48H 2nd Class, D: Special Delivery Guaranteed, H: HM Forces (BFPO), I: International, R: Tracked Returns, T: Tracked Domestic)
                referenceDataType serviceType = new referenceDataType();
                serviceType.code = shippingForm.GetServiceType().GetServiceTypeCode();
                shipment.serviceType = serviceType;
                // Service Offering (See Royal Mail Service Offering Type Codes. Too Many To List)
                serviceOfferingType serviceOfferingTypeContainer = new serviceOfferingType();
                referenceDataType serviceOffering = new referenceDataType();
                serviceOffering.code = shippingForm.GetServiceOffering().GetCode();
                serviceOfferingTypeContainer.serviceOfferingCode = serviceOffering;
                shipment.serviceOffering = serviceOfferingTypeContainer;
                // Service Format Code
                serviceFormatType serviceFormatTypeContainer = new serviceFormatType();
                referenceDataType serviceFormat = new referenceDataType();
                serviceFormat.code = shippingForm.GetServiceFormat().GetFormat();
                serviceFormatTypeContainer.serviceFormatCode = serviceFormat;
                shipment.serviceFormat = serviceFormatTypeContainer;
                // Shipping Date
                shipment.shippingDate = shippingForm.GetShippingDate();
                shipment.shippingDateSpecified = true;
                // Signature Required (Only Available On Tracked Services)
                if (shippingForm.IsSignatureRequired())
                {
                    shipment.signature = true;
                }
                else
                {
                    shipment.signature = false;
                    // Leave In Safe Place (Available On Tracked Non Signature Service Offerings)
                    shipment.safePlace = shippingForm.GetSafePlaceText();
                }
                shipment.signatureSpecified = true;
                // Sender Reference Number (e.g. Invoice Number or RA Number)
                shipment.senderReference = shippingForm.GetInvoiceNumber();
                /*
                 * Service Enhancements
                */
                List<serviceEnhancementType> serviceEnhancements = new List<serviceEnhancementType>();
                List<dataObjects.ServiceEnhancement> selectedEnhancements = shippingForm.GetServiceEnhancements();
                for (int i = 0; i < selectedEnhancements.Count; i++)
                {
                    serviceEnhancementType enhancement = new serviceEnhancementType();
                    referenceDataType enhancementCode = new referenceDataType();
                    enhancementCode.code = selectedEnhancements.ElementAt(i).GetEnhancementType().ToString();
                    enhancement.serviceEnhancementCode = enhancementCode;
                    serviceEnhancements.Add(enhancement);
                }
            
                shipment.serviceEnhancements = serviceEnhancements.ToArray();
                /*
                 * Recipient Contact Details
                */
                contact recipientContact = new contact();
                recipientContact.complementaryName = shippingForm.GetCompany();
                recipientContact.name = shippingForm.GetName();
                if(!shippingForm.GetEmailAddress().Equals("")) {
                    digitalAddress email = new digitalAddress();
                    email.electronicAddress = shippingForm.GetEmailAddress();
                    recipientContact.electronicAddress = email;
                }
                if(!shippingForm.GetMobileNumber().Equals("")) {
                    telephoneNumber tel = new telephoneNumber();
                    
                    Regex phoneRegex = new Regex(@"[^\d]");
                    tel.telephoneNumber1 = phoneRegex.Replace(shippingForm.GetMobileNumber(), "");
                    tel.countryCode = "00" + shippingForm.GetCountry().GetDialingCode();
                    recipientContact.telephoneNumber = tel;
                }
                shipment.recipientContact = recipientContact;
                /*
                 * Recipient Address
                 * 
                */
                address recipientAddress = new address();
                recipientAddress.addressLine1 = shippingForm.GetAddressLine1();
                recipientAddress.addressLine2 = shippingForm.GetAddressLine2();
                recipientAddress.addressLine3 = shippingForm.GetAddressLine3();
                recipientAddress.addressLine4 = shippingForm.GetCounty();
                recipientAddress.postTown = shippingForm.GetTown();
                countryType country = new countryType();
                referenceDataType countryCode = new referenceDataType();
                countryCode.code = shippingForm.GetCountry().getCountryCode();
                country.countryCode = countryCode;
                recipientAddress.country = country;
                recipientAddress.postcode = shippingForm.GetPostCode();
                recipientAddress.stateOrProvince = new stateOrProvinceType();
                recipientAddress.stateOrProvince.stateOrProvinceCode = new referenceDataType();
                shipment.recipientAddress = recipientAddress;
                // Shipment Items
                
                List<RoyalMailAPI.RoyalMailShippingAPI.item> items = new List<RoyalMailAPI.RoyalMailShippingAPI.item> ();
                foreach(dataObjects.Item i in shippingForm.GetItems()) {
                    RoyalMailAPI.RoyalMailShippingAPI.item item = new RoyalMailAPI.RoyalMailShippingAPI.item();
                    item.numberOfItems = i.GetQty().ToString();
                    item.weight = new dimension();
                    item.weight.value = (float) (i.GetWeight() * 1000);
                    item.weight.unitOfMeasure = new unitOfMeasureType();
                    item.weight.unitOfMeasure.unitOfMeasureCode = new referenceDataType();
                    item.weight.unitOfMeasure.unitOfMeasureCode.code = "g";
                    items.Add(item);
                }
                if (shippingForm.GetServiceType().GetDescription().ToLower().Contains("international"))
                {
                    internationalInfo InternationalInfo = new internationalInfo();
                    InternationalInfo.shipperExporterVatNo = "GB945777273";
                    InternationalInfo.documentsOnly = false;
                    InternationalInfo.shipmentDescription = "Invoice Number: " + shippingForm.GetInvoiceNumber();
                    InternationalInfo.invoiceDate = DateTime.Now;
                    InternationalInfo.termsOfDelivery = "EXW";
                    InternationalInfo.invoiceDateSpecified = true;
                    InternationalInfo.purchaseOrderRef = shippingForm.GetInvoiceNumber();
                    List<RoyalMailShippingAPI.parcel> parcels = new List<parcel>();
                    foreach (dataObjects.Item i in shippingForm.GetItems())
                    {
                        parcel Parcel = new parcel();
                        Parcel.weight = new dimension();
                        Parcel.weight.value = (float)(i.GetWeight() * 1000);
                        Parcel.weight.unitOfMeasure = new unitOfMeasureType();
                        Parcel.weight.unitOfMeasure.unitOfMeasureCode = new referenceDataType();
                        Parcel.weight.unitOfMeasure.unitOfMeasureCode.code = "g";
                        Parcel.invoiceNumber = shippingForm.GetInvoiceNumber();
                        Parcel.purposeOfShipment = new referenceDataType();
                        Parcel.purposeOfShipment.code = "31";
                        List<contentDetail> Contents = new List<contentDetail>();
                        foreach (RoyalMailAPI.dataObjects.ProductDetail product in i.GetProducts())
                        {
                            contentDetail ContentDetail = new contentDetail();
                            ContentDetail.articleReference = product.Sku;
                            ContentDetail.countryOfManufacture = new countryType();
                            ContentDetail.countryOfManufacture.countryCode = new referenceDataType();
                            ContentDetail.countryOfManufacture.countryCode.code = product.CountryOfManufacture;
                            ContentDetail.currencyCode = new referenceDataType();
                            ContentDetail.currencyCode.code = product.CurrencyCode;
                            ContentDetail.description = product.Name;
                            ContentDetail.unitQuantity = product.Qty.ToString();
                            ContentDetail.unitValue = Convert.ToDecimal(product.Price);
                            ContentDetail.unitWeight = new dimension();
                            ContentDetail.unitWeight.value = Convert.ToSingle(product.Weight * 1000);
                            ContentDetail.unitWeight.unitOfMeasure = new unitOfMeasureType();
                            ContentDetail.unitWeight.unitOfMeasure.unitOfMeasureCode = new referenceDataType();
                            ContentDetail.unitWeight.unitOfMeasure.unitOfMeasureCode.code = "g";
                            Contents.Add(ContentDetail);
                        }
                        //Parcel.contentDetails = Contents.ToArray();
                        parcels.Add(Parcel);
                    }
                    InternationalInfo.parcels = parcels.ToArray();
                    shipment.internationalInfo = InternationalInfo;
                }
                else
                {
                    shipment.items = items.ToArray();
                }
                request.requestedShipment = shipment;
                createShipmentResponse response = client.createShipment(GetSecurityHeaderType(), request);
                // Show Errors And Warnings
                checkErrorsAndWarnings(response.integrationFooter);
                
                return response;
            }
            catch (TimeoutException e)
            {
                client.Abort();
                MessageBox.Show("Request Timed Out: " + e.Message, "Request Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (FaultException e)
            {
                client.Abort();
                showSoapException(e);
            }
            catch (CommunicationException e)
            {
                client.Abort();
                MessageBox.Show("A communication error has occured: " + e.Message + " - " + e.StackTrace, "Communication Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            catch (Exception e)
            {
                client.Abort();
                MessageBox.Show(e.Message, "Royal Mail Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            return null;
        }
