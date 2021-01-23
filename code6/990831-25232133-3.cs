    public class Catalog
    {
        public Catalog Parent { get; set; }
        public IEnumerable<Catalog> Children { get; set; }
        public string CatalogName { get; set; }
    }
    public class Model
    {
         public Catalog Catalog { get; set; }
         public string ItemName { get; set; }   
    }
