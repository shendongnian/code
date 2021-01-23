    public PriceObj
    {
        public int CompanyID { get; set; }
        public decimal Price { get; set; }
    }
    public class PriceEditorViewModel
    {
         public ObservableCollection<PriceObj> Prices { ... }
         /* ... */
    }
