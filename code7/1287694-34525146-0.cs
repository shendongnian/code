    public ActionResult Add_Product(int? page)
        {
    
            var dummyItems = db.AB_ProductTypeCategoryField;
            var pager = new PaginationModel.Pager(dummyItems.Count(), page);
    
    
            var model = new AddNewProduct
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager
            };
    
            return View(model);
    
        }
