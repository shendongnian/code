    public class Companies(){
      public double Popularity { get; set; }
      public List<ProductionCompany> Production_Companies { get;set; }
     
      public Companies(){
        Production_Companies  = new List<ProductionCompany>();
      }
    }
    public class ProductionCompany(){
       public string Name {get;set;}
       public int Id {get;set;}
    }
