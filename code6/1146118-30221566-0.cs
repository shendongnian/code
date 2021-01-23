    public class InvoiceViewModel
    {
        ...
        public int CountryID { get; set; }
        public SelectList Countries { get; set; }
        // or
        public List<Country> Countries { get; set; }
        ...
    }
