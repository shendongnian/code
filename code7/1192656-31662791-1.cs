    using AccessorizeForLess.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    
    namespace AccessorizeForLess.ViewModels
    {
        public class AddNewProductViewModel
        {
            public string Name { get; set; }
    
            [DataType(DataType.MultilineText)]
            public string Description { get; set; }
    
            public decimal Price { get; set; }
    
            public string AltText { get; set; }
    
            public int Quantity { get; set; }
    
            public HttpPostedFileBase Image { get; set; }
    
            public int SelectedCategoryId {get;set;}
            public List<ProductCategory> Categories { get; set; }
            public ProductCategory Category { get; set; }
        }
    }
