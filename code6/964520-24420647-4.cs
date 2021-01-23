    public class MemberTransaction : IEquatable<MemberTransaction>
    {
        public int BatchNo { get; set; }
        public DateTime TranDate { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public int ReceiptNo { get; set; }
        public int CheckNo { get; set; }
        public int SocSecNo { get; set; }
        public bool Equals(MemberTransaction other)
        {
            return BatchNo == other.BatchNo
                   && TranDate.Equals(other.TranDate)
                   && DebitAmount == other.DebitAmount
                   && CreditAmount == other.CreditAmount
                   && ReceiptNo == other.ReceiptNo
                   && CheckNo == other.CheckNo
                   && SocSecNo == other.SocSecNo;
        }
    }
