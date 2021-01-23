    abstract class Bouquet
        {
            private List<Flower> _flowers = new List<Flower>();
            public List<Flower> Flowers
            {
                get { return _flowers; }
                private set { _flowers = value; }
            }
            public decimal Cost { get { return _flowers.Sum(p => p.Price); } }
            public int Count { get { return _flowers.Count(); } }
            public Bouquet()
            {
                
                
            }
    
    
    
    
            //Factory method
            public abstract void CreateBouquet();
        }
