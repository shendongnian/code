    public class DeliveryEditViewModel
    {
        public int DeliveryID { get; set; }        
        public string SelectedCompanyName { get; set; }
        public IEnumerable<Supplier> suppliers { get; set; }
    }
