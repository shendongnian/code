    public ActionResult Add_Product(int? page)
        {
            var pager = new PaginationModel.Pager(dummyItems.Count(), page);
    
            var model = new AddNewProduct
            {
                ListProductFields = db.AB_ProductTypeCategoryField.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList(),
                Pager = pager
            };
    
            return View(model);
    
        }
