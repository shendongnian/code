    public async Task<IEnumerable<ProductCategory>> getAllCategories()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<ProductCategory>("productcategory");
            var documents = collection.Find(_ => true).ToListAsync();//.ContinueWith(e=>e.Result.AsEnumerable());
            documents.Wait();
            var b = documents.Result.AsEnumerable();
            IEnumerable<ProductCategory> ie = (IEnumerable<ProductCategory>)b;
            return ie;
        }
    
        public ActionResult Index()
        {
            var categoryService = new ProductCategoryService();
            var categoryDetails = categoryService.getAllCategories().Result;
            return View(categoryDetails);
        }
