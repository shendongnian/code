    <OrderTransactions>
      <OrderTransaction>
        <LoanAmount /> --this may be NULL - this should not cause the message to fail. 
        <Title>
          <TitleVendors>
             <TitleVendor>
                <VendorInstructions>Endorsements required: EPA, COMP, PUD. **Attention Abstractor: THIS IS A VA LOAN** **Attention Abstractor: If a PRIVATE ROAD EASEMENT exists, please provide any information and copies along with the abstract.</VendorInstructions> 
             <VendorServices>
               <TitleVendorService>
                 <TitleVendorServiceId>6615159</TitleVendorServiceId> 
                 <ServiceCode>1OWNER</ServiceCode> 
                 <CustomVendorInstructions><p><b>Copies of recital page, legal description and signature pages of all open mortgages must be provided including copies of the legal description and any riders.<br /> <br /> Copies of assignments must be provided for open liens.<br /> <br /> If the property is registered land a copy of the certificate of title must accompany the search</CustomVendorInstructions> 
               </TitleVendorService>
            </VendorServices>
         </TitleVendor>
       </TitleVendors>
      </Title>
     </OrderTransaction>
    </OrderTransactions>
    [XmlArray("OrderTransactions")]
    [XmlArrayItem("OrderTransaction")]
    public List<OrderTransaction> OrderTransactions = new List<OrderTransaction>();
            public class OrderTransaction
            {
                [XmlElement("LoanAmount")]
                [DataMember]
                public string LoanAmount { get; set; }
                [XmlArray("Title")]
                [XmlArrayItem("TitleVendors")]
                public List<Title> Titles = new List<Title>();
                        public class Title
                        {
                            [XmlArray("TitleVendor")]
                            [XmlArrayItem("VendorInstructions")]
                            //[XmlArrayItem("VendorServices")]
                            public List<TitleVendor> TitleVendors = new List<TitleVendor>();
                                    public class TitleVendor
                                    {
                                        [XmlElement("VendorInstructions")]
                                        [DataMember]
                                        public string VendorInstructions { get; set; }
                                        [XmlArray("VendorServices")]
                                        [XmlArrayItem("TitleVendorService")]
                                        public List<VendorService> VendorServices = new List<VendorService>();
                                                public class VendorService
                                                {
                                                    public List<TitleVendorService> TitleVendorServices = new List<TitleVendorService>();
                                                            public class TitleVendorService
                                                            {
                                                                [XmlElement("TitleVendorServiceId")]
                                                                [DataMember]
                                                                public string TitleVendorServiceId { get; set; }
                                                                [XmlElement("ServiceCode")]
                                                                [DataMember]
                                                                public string ServiceCode { get; set; }
                                                                [XmlElement("CustomVendorInstructions")]
                                                                [DataMember]
                                                                public string CustomVendorInstructions { get; set; }
                                                            }
                                                }
                                    }
                        }
            }
