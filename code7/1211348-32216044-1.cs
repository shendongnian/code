    public class MaterialColor : ICacheableEntity
    {
        public virtual Material Material { get; set; }
        public virtual Color Color { get; set; }
        public int ColorId { get; set; }
        public int MaterialId { get; set; }
    }
