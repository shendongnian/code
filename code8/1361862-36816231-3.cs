    public abstract class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public float volume { get; set; }
        public float minPrice { get; set; }
        public float mass { get; set; }
        public string description { get; set; }
    
        public virtual void Parse( string[] entries )
        {
            int i = 0;
            id = int.Parse( entries[ i++ ] );
            name = entries[ i++ ];
            minPrice = float.Parse( entries[ i++ ] );
            volume = float.Parse( entries[ i++ ] );
            mass = float.Parse( entries[ i++ ] );
            description = RemoveTabs( entries[ i ] );
        }
    
        public string RemoveTabs( string line ) { throw new NotImplementedException(); }
    }
    
    public class Commodity : Item
    {
    }
    
    public class Weapon : Commodity
    {
    }
    
    public class CommodityC : Item
    {
    }
    
    
    public class ItemManager
    {
    
        private Item ProcessCommodity( string[] entries )
        {
            var commodity = new Commodity();
            var weapon = new Weapon();
    
            commodity.Parse( entries );
            //weapon.Parse( entries );
            return commodity;
        }
    }
