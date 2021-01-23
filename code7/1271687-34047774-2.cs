    private void LoadCreateViewBagData()
    {
        string domain = Request.Url.Host;
        int clientid = (from a in db.Client where a.Domain == domain select a.ID).First();
        int maxID = db.Product.Where(c => c.ClientID == clientid).Max(c => (int?)c.ProductID) ?? 0;
            
        ViewBag.MaxID = maxID + 1;
        List<SelectListItem> categories = new List<SelectListItem>();
        foreach (var cat in db.Category.Where(c => c.ClientID == clientid))
        {
            categories.Add(new SelectListItem() { Text = cat.Name, Value = cat.CategoryID.ToString() });
        }
            
        ViewBag.Categories = categories;
    }
    // GET: Admin/Products/Create
    public ActionResult Create()
    {
        LoadCreateViewBagData();
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ID,ProductID,Name,CategoryID,Price,Promotion,Image1,Image2,Image3,Image4,Description,ClientID")] Product product, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
    {
        if (ModelState.IsValid)
        {
            //yada yada
        }
        LoadCreateViewBagData();
        return View(product);
    }
