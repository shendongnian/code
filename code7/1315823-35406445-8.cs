    public class ProductViewModel
    {
        public ProductViewModel() 
        { 
            EditableProduct = new Product();
        }
        public List<SelectListItem> Categories { get; set; }
        public Product EditableProduct { get; set; }
    }
