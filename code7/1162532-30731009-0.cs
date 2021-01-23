    public class Supplier
    {
        //...
        public string SupplierName { get; set; }
        public string AccountNumber { get; set; }
        //...
        public string DisplayName
        {
            get { return String.Format("{0} ({1})", SupplierName, AccountNumber); }
        }
    }
