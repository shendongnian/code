    //delimiters, ignore first row, separate with comma
    [DelimitedRecord(",")]
    [IgnoreFirst()]
    public class CauseofDeathClass
    {    
        public int Year { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Ethnicity { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Sex { get; set; }
        [FieldQuoted('"', QuoteMode.OptionalForBoth)]
        public string Cause_of_Death { get; set; }
        public int Count { get; set; }
        public int Percent { get; set; }
    }
