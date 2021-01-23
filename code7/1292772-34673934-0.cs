    public ActionResult Index()
        {
            List<Product> products;
            using (FastfoodConnection conn = new FastfoodConnection())
            {
                products = conn.Products.Include(p => p.Ingredients).ToList();
            }
            TestModel tM = new TestModel();
            tM.Products = products;
            return View(tM);
        }
