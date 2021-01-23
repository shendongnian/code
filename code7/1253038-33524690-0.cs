    public class StockMap : ClassMap<Stock>
    {
        public StockMap()
        {
            CompositeId( stock => stock.ID)
                .KeyProperty(x => x.CodigoInterno)
                .KeyProperty(x => x.Token);
            // ... Other Maps and References
            //This is ok since you have (i believe) a column in
            //in your table that stores the id from Producto
            References(x => x.ProductoStock).Column("idProducto");
            //Maybe you have to put the name of the column with
            //the id of Producto in your table Stock because
            //you could use it later.
        }
    }
