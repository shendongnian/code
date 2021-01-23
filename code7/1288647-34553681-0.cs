    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;
    
    namespace MvcApplication1.Models
    {
        [MetadataType(typeof(productMetadata))]
        public partial class Product
        {
    
        }
    
        public class productMetadata
        {
            [HiddenInput(DisplayValue = false)]
            public int ProductId { get; set; }
    
            // to make the field hidden and will not display in browser
            [HiddenInput(DisplayValue = false)]
            //directing that don't scaffold this column since it will be added manually
            [ScaffoldColumn(false)]
            public int UserId { get; set; }
        }
    }
