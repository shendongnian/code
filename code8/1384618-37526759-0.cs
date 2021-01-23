    public class Purchase
    {
       public Purchase(){
          Inventory = new HashSet<Inventory>();
       }
       public ICollection<Inventory> Inventory { get; set; }
    }
