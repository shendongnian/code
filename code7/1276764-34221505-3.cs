    public ActionResult Produkt(int? ProductID)
            {
                string domain = Request.Url.Host;
                int clientid = (from a in db.Client where a.Domain == domain select a.ID).First();
    
                int categoryID = db.Category.Where(b => b.ClientID == clientid && b.Name == "Okienne").Select(b => b.ID).First();
    
                var ProductViewModel = new ProductViewModel();
                ProductViewModel.Products = db.Product.Where(c => c.ClientID == clientid && c.CategoryID == categoryID).ToList();
                ProductViewModel.ProductDetails = db.Product.SingleOrDefault(c => c.ClientID == clientid && c.CategoryID == categoryID && c.ProductID == ProductID);
    
                return View(ProductViewModel);
