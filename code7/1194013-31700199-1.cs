    [Table("TemporaryCsvUpload")]
    public class OutstandingCredit
    {
        [CsvColumn(FieldIndex = 1, CanBeNull = false)]
        public string Id { get; set; }
        [CsvColumn(FieldIndex = 2, OutputFormat = "dd MMM HH:mm:ss")]
        public DateTime? InvoiceDate { get; set; }
        [CsvColumn(FieldIndex = 3)]
        public string InvoiceNumber { get; set; }
        [CsvColumn(FieldIndex = 4, OutputFormat = "C")]
        public decimal? InvoiceAmount { get; set; }
        [CsvColumn(FieldIndex = 5, OutputFormat = "dd MMM HH:mm:ss")]
        public DateTime? DeniedDate { get; set; }
        [CsvColumn(FieldIndex = 6)]
        public int? DeniedReasonId { get; set; }
        [CsvColumn(FieldIndex = 7)]
        public string DeniedNotes { get; set; }
    }
