    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    namespace Activity.Models
    {
    [Table("PruProductDetails")]
    public class Products
    {
        [Key]
        public int ProductKey { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Discountable { get; set; }
        public string DateAdded { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public int ReOrderLevel { get; set; }
        public int OrderLimit { get; set; }
    }
}
