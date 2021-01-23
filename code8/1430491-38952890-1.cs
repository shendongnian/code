    public class SaveDecimal
    {
        private decimal DecValue;
        public SaveDecimal(decimal Value)
        {
            DecValue = Value;
        }
        public decimal GetValue()
        {
            return DecValue;
        }
        public static SaveDecimal operator +(SaveDecimal A, SaveDecimal B)
        {
            decimal almostMax = Decimal.MaxValue - 1;
            checked
            {
                if (almostMax <= A.GetValue() + B.GetValue())
                    throw new Exception("----scary error message----");
            }
            return new SaveDecimal(A.GetValue() + B.GetValue());
        }
    }
