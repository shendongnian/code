    using AMBIT_CMS_MVC.Areas.Admin.Models;
    namespace AMBIT_CMS_MVC.Models
    {
        public class ProductViewModel
        {
            public IEnumerable<Product> Products { get; set; }
            public Product ProductDetails { get; set; }
        }
    }
