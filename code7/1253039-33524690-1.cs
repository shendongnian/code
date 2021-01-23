    public class ProductoMap : ClassMap<Producto>
    {
        public ProductoMap()
        {
            Id(x => x.Id);
            // ... Other Maps and References
            //If you have the id from Stock in your Stock class
            //this will work.
            //References<Stock>( p => p.Stock);
            //If you don't have it, this will work:
            HasOne<Stock>(x => x.Stock).PropertyRef("Name of the column whit the product id in the Stock table");
        }
    }
