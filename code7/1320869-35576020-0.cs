     public string A { get; set; }
        public string B { get; set; }
        public Sample(string strSplit) {
            var values = strSplit.Split(',');
            A = values[0];
            B = values[1];
        }
    Sample dd = new Sample("James,Jonathan");
