    var xmlString = @
    "<OrderDetail>
        <MessageTypeCode>82540</MessageTypeCode>
        <OrderDetailId>59339463</OrderDetailId>
        <ClientInfo>
            <ClientName>LenderName will appear here</ClientName>
        </ClientInfo>
        <OrderTaxes>
            <OrderTax>
                <TaxId>9202225</TaxId>
            </OrderTax>
        </OrderTaxes>
        <OrderTransactions>
            <OrderTransaction>
                <LoanAmount/>
                <Title>
                    <TitleVendors>
                        <TitleVendor>
                            <VendorInstructions>blah blah blah blah .</VendorInstructions>
                            <VendorServices>
                                <TitleVendorService>
                                    <TitleVendorServiceId>6615159</TitleVendorServiceId>
                                    <ServiceCode>1OWNER</ServiceCode>
                                    <CustomVendorInstructions>blah blah blah blah blah </CustomVendorInstructions>
                                </TitleVendorService>
                            </VendorServices>
                        </TitleVendor>
                    </TitleVendors>
                </Title>
            </OrderTransaction>
        </OrderTransactions>
    </OrderDetail>";
    
    var xml = new OrderDetail();
    
    System.Xml.Serialization.XmlSerializer serializer = new
    System.Xml.Serialization.XmlSerializer(typeof(OrderDetail));
    
    using(XmlReader reader = XmlReader.Create(new StringReader(xmlString))) {
    	xml = (OrderDetail) serializer.Deserialize(reader);
    }
    
    var xmlDump = xml.Dump();
