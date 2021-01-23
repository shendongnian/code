        [System.SerializableAttribute()]
        [XmlRoot("ACABulkRequestTransmitterStatusDetailResponse", Namespace = "urn:us:gov:treasury:irs:msg:irstransmitterstatusrequest")]
        public class ACABulkRequestTransmitterStatusDetailResponseType
        {
            private ACABulkRequestTransmitterResponseType aCABulkRequestTransmitterResponseField;
            private ACABulkReqTrnsmtStsRespGrpDtlType aCABulkReqTrnsmtStsRespGrpDtlField;
            private string versionField;
            public ACABulkRequestTransmitterStatusDetailResponseType()
            {
                this.versionField = "1.0";
            }
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:gov:treasury:irs:ext:aca:air:7.0", Order = 0)]
            public ACABulkRequestTransmitterResponseType ACABulkRequestTransmitterResponse
            {
                get
                {
                    return this.aCABulkRequestTransmitterResponseField;
                }
                set
                {
                    this.aCABulkRequestTransmitterResponseField = value;
                }
            }
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:us:gov:treasury:irs:ext:aca:air:7.0", Order = 1)]
            public ACABulkReqTrnsmtStsRespGrpDtlType ACABulkReqTrnsmtStsRespGrpDtl
            {
                get
                {
                    return this.aCABulkReqTrnsmtStsRespGrpDtlField;
                }
                set
                {
                    this.aCABulkReqTrnsmtStsRespGrpDtlField = value;
                }
            }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }
        }
