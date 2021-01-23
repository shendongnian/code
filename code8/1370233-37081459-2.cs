    public class Item1{
      public int Item1Id{get;set;}
      public ICollection<Item2> Item2s{ get; set; }
    }
    public class Item2{
      public int Item2Id{get;set;}
      //Not in db. Ignored field in mapping
      [NotMapped]
      public int Item3Count => Item3s.Count;
      //this is the FK
      public int Item1Id{get;set;}
    
      public Item1 Item1 {get;set;}
      public ICollection<Item3> Item3s{ get; set; }
    }
    public class Item3{
      public int Item3Id;
      
      //FK
      public int Item2Id {get;set;}
      public Item2 Item2 {get;set;}
    }
