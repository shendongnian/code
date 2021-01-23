    public class MainVM // rename as required
    {
      public string SelectedDay { get; set; }
      public List<DeliveryDateVM> Days { get; set; }
    }
    public class DeliveryDateVM
    {
        public int Id { get; set; }
        public string DeliveryDay { get; set; }
        public string DeliveryType { get; set; }
    }
