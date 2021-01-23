    public class InventoryVM
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public bool IsSelected { get; set; }
    }
    public class OrderVM
    {
      public string PaymentMethod { get; set; }
      public List<InventoryVM> Inventory { get; set; }
    }
