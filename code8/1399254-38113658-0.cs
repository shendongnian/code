    public async Task<IViewComponentResult> InvokeAsync()
    {
       var res = await (from p in ctx.Products
                           where p.ProductName.StartsWith(filter)
                           select p).ToListAsync();
    
                return View(res);
    }
    
    @await Component.InvokeAsync("ProductList", "D")
