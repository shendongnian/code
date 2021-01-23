    public class ProductService : IProductService
    {
        private EfDatabase db = new EfDatabase();
    
        public async Task<string> CreateProduct(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Create");
            var product = new Product
            {
                Name = model.Name,
                Presentation = model.Presentation,
                Image = model.Image,
                Alt = model.Alt,
                SubcategoryId = model.SelectedSubcategory,
                IsDeleted = false
            };
            db.ProductsList.Add(product);
            await db.SaveChangesAsync();
            return "Product " + model.Name + "has been created";
        }
    }
