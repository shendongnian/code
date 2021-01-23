    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.ProductRecept = new HashSet<ProductRecept>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductRecept> ProductRecept { get; set; }
    } 
    public partial class Material
    {
        public Material()
        {
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class ProductRecept
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MaterialId { get; set; }
        public decimal Qu { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Material Material { get; set; }
    }
