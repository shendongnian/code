    public class MyViewModel
    {
        public bool UseLocalProductOnly { get; set }
        public int SelectedProduct{ get; set; }
        public IEnumerable<SelectListItem> ProductList { get; set; }
        public IEnumerable<int> LocalProducts { get; set; }
    }
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsLocalProduct { get; set; }
    }
