    public class CieLab
    {
        public double L { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public static double DeltaE(CieLab l1, CieLab l2)
        {
            return Math.Pow(l1.L - l2.L, 2) + Math.Pow(l1.A - l2.A, 2) + Math.Pow(l1.B - l2.B, 2);
        }
        public static CieLab Combine(CieLab l1, CieLab l2, double amount)
        {
            var l = l1.L * amount + l2.L * (1 - amount);
            var a = l1.A * amount + l2.A * (1 - amount);
            var b = l1.B * amount + l2.B * (1 - amount);
            return new CieLab { L = l, A = a, B = b };
        }
    }
