    public class SafeDecimal
    {
        private decimal DecValue;
        public SafeDecimal(decimal Value)
        {
            DecValue = Value;
        }
        public decimal GetValue()
        {
            return DecValue;
        }
        public static SafeDecimal operator +(SafeDecimal A, SafeDecimal B)
        {
            decimal almostMax = Decimal.MaxValue - 1;
            checked
            {
                if (almostMax <= A.GetValue() + B.GetValue())
                    throw new Exception("----scary error message----");
            }
            return new SafeDecimal(A.GetValue() + B.GetValue());
        }
    }
