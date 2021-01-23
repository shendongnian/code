    public class YourPageVm
    {
      public List<ItemVm> Categories { set;get;}
      public YourPageVm()
      {
         this.Categories = new List<ItemVm>();
      }
    }
    public class ItemVm
    {
      public int Id { set;get;}
      public string Name { set;get;}
    }
