    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}
    public class Item
    {
        public ItemQuality ItemQuality { get; set; }
    
        // other things common to all items here
    
        public List<IFeature> features { get; set; }
    }
