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
            if (ReferenceEquals(null, other))
                return false;
            
            if (ReferenceEquals(this, other))
                return true;
            return BatchNo == other.BatchNo
                   && TranDate.Equals(other.TranDate)
                   && DebitAmount == other.DebitAmount
                   && CreditAmount == other.CreditAmount
                   && ReceiptNo == other.ReceiptNo
                   && CheckNo == other.CheckNo
                   && SocSecNo == other.SocSecNo;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = BatchNo;
                hashCode = (hashCode*397) ^ TranDate.GetHashCode();
                hashCode = (hashCode*397) ^ DebitAmount.GetHashCode();
                hashCode = (hashCode*397) ^ CreditAmount.GetHashCode();
                hashCode = (hashCode*397) ^ ReceiptNo;
                hashCode = (hashCode*397) ^ CheckNo;
                hashCode = (hashCode*397) ^ SocSecNo;
                return hashCode;
            }
        }
        public static bool operator ==(MemberTransaction left, MemberTransaction right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(MemberTransaction left, MemberTransaction right)
        {
            return !Equals(left, right);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            
            return Equals((MemberTransaction) obj);
        }
    }
