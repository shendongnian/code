    class Product
    {
       public string Name { get; set; }
       public Dictionary<string, Position> PositionList { get; set; }
       public Product()
       {
          PositionList = new Dictionary<string, Position>();
       }
    }
