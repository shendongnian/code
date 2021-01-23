    public struct TaxPayer
    {
        public string SSN { get; set; }
        public decimal Gross { get; set; }
        public decimal Tax { get; set; }
        public static string Formatting="{0,-12} {1,-13} {2,-13}";
        public static string Heading { get { return string.Format(Formatting, new string[] { "SSN Number", "Gross Income", "Taxes" }); } }
        public override string ToString()
        {
            return string.Format(Formatting,
                new string[] { SSN, Gross.ToString("C"), Tax.ToString("C") });
        }
    }
