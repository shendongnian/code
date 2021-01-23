    public class ViewQuoteItemList
    {
        public ViewQuoteItemList()
        {
            Suppliers = new ObservableDictionary<string, string>();
        }
        public int Id { get; set; }
        public string Item { get; set; }
        public ObservableDictionary<string, string> Suppliers { get; set; }
    }
