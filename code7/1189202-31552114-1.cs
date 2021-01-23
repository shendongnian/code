    public class BouquetViewModel
    {
      ....
      public List<FlowerViewModel> FlowerList { get; set; }
    }
    public class FlowerViewModel
    {
      public int ID { get; set; }
      public string Name { get; set; }
      public bool IsSelected { get; set; } // add this
    }
