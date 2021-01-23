    using System.ComponentModel.DataAnnotations.Schema;
    public class SizeCount
    {
        public int Id { get; set; }
        public int Count { get; set; }
        [Index("IX_SizeUnique", 1, IsUnique = true)]
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }
         [Index("IX_ColorUnique", 1, IsUnique = true)]
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
         [Index("IX_ProductUnique", 1, IsUnique = true)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
       
    }
    public class Product
        {
            public int Id { get; set; }
        }
    
        public class Color
        {
            public int Id { get; set; }
        }
    
        public class Size
        {
            public int Id { get; set; }
        }
