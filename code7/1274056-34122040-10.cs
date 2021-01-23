    public ActionResult Details(int? id)
    {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        Product product = db.Products.Find(id);
        if (product == null)
            return HttpNotFound();
        // Read list of recent products from session
        var list = Session["RecentProductList"] as List<RecentProduct>;
        if (list == null)
        {
            // If list not found in session, create list and store it in a session
            list = new List<RecentProduct>();
            Session["RecentProductList"] = list;
        }
        // Add product to recent list (make list contain max 10 items; change if you like)
        AddRecentProduct(list, id.Value, product.Name, 10);
        // Store recentProductList to ViewData keyed as "RecentProductList" to use it in a view
        ViewData["RecentProductList"] = list;
        return View(product);
    }
