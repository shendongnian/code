    public class Transaction
    {
        private int maxLengthPlace = 80
        public DateTime R03DateFrom { get; set; }
        public DateTime? R03DateTo { get; set; }
        [MaxLength(maxLengthPlace)]
        public string R03Place { get; set; }
        [MaxLength(20)]
        public string R03Code { get; set; }
        // And so on....
    }
