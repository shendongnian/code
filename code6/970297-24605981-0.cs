    public async Task<ActionResult> LoadNew()
    {
        var viewModel = new CategoryViewModel();
        viewModel.Products = await db.Products.Include(c => c.Reviews).Include(c => c.CategoryContents).Include(c => c.Affiliates).ToListAsync();
        return View("_NewProducts", viewModel);
    }
