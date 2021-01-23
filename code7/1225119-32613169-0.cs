    public class LineItem
    {
        public static LineItem Parse(string line)
        {
            var split = line.Split('|');
            return new LineItem(split[0], split[1], split[2], split[3], split[4], split[5], split[6]);
        }
        public LineItem(string s0, string s1, string s2, string s3, string s4, string s5, string s6)
        {
            //any param value checks
            S0 = s0;
            S1 = s1;
            S2 = s2;
            S3 = s3;
            S4 = s4;
            S5 = s5;
            S6 = s6;
        }
        public string S0 { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public string S5 { get; set; }
        public string S6 { get; set; }
    }
    public class LineItemValidator : AbstractValidator<LineItem>
    {
        public LineItemValidator()
        {
            RuleFor(line => line.S0).Length(1);
            RuleFor(line => line.S2).Length(6);
            //etc
        }
    }
