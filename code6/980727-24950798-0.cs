    public partial class VoucherHeader
    {
        [DataMember]
        public string RelatedDescription
        {
            set { }
            get
            {
                if (VoucherHeader2 != null) return VoucherHeader2.Description;
                else return "";
            }
        }
    }
