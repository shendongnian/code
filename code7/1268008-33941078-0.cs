    public class ProductDetailsViewModel {
        // Display attribute as an example of a view concern
        [Display(Name = "ProductDetails_Name", ResourceType = typeof(Resources))]
        public string Name {get; set;}
    }
     
    public class ProductListViewModel {
        public IEnumerable<ProductDetailsViewModel> ProductDetails {get; set;}
    }
    // Example of mapping by hand:
    var item1 = new Item1();
    var item2 = new Item2();
    var vm1 = new ProductDetailsViewModel { Name = item1.Name };
    var vm2 = new ProductDetailsViewModel { Name = item2.Name };
    var productList = new ProductListViewModel {ProductDetails = new [] {vm1, vm2}}; 
