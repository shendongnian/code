    // GET: Products/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                Product = await db.Products.SingleOrDefaultAsync(x => x.Id == id),
                ProductCategories = await db.ProductCategories.Where(x => x.ProductId == id).ToListAsync()
            };
            return View(model);
        }
