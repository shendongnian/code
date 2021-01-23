    class Program
    {
        static void Main(string[] args)
        {
            SaveDecimal SmallNumber = new SaveDecimal(10);
            SaveDecimal Overflow = new SaveDecimal(decimal.MaxValue - 5);
            Console.WriteLine(SmallNumber.GetValue());
            Console.WriteLine(SmallNumber + Overflow); //trows an exception
        }
    }
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
            if(A.GetValue() + B.GetValue() < A.GetValue()) //a simple way to check for overflow
                throw new OverflowException();
            return new SaveDecimal(A.GetValue() + B.GetValue());
        }
    }
