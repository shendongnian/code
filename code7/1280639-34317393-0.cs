    class Program
    {
        Piggybank piggybank = new Piggybank();
        static void Main(string[] args)
        {
            piggybank.TenPesos += (int)tenpeso.Value * 10;
            piggybank.FivePesos += (int)fivepeso.Value * 5;
            piggybank.OnePesos += (int)onepeso.Value * 1;
            piggybank.TwoFiveCents += (int)twofivecent.Value * .25;
            piggybank.TenCents += (int)tencent.Value * .10;
            piggybank.FivePesos += (int)fivecent.Value * .05;
        }
    }
    public class Piggybank
    {
        public int TenPesos;
        public int FivePesos;
        public int OnePesos;
        public int TenCents;
        public int TwoFiveCents;
        public int FiveCents;
        public int Total
        {
            get { return TenPesos + FivePesos + OnePesos + TwoFiveCents + TenCents + FiveCents; }
        }
    }
