    private IEnumerable<SelectListItem> GetMyItemsSelectItems()
    {
       return (from s in _rep.GetMyItems()
               select new SelectListItem
                {
                    Text = s.MyItemName,
                    Value = s.ID.ToString()
                 }).AsEnumerable();
     }
    
     public ActionResult Create()
     {
         ViewBag.MyItems = GetMyItemsSelectItems();
    
         return View(new MyItem { ID = 1, Forign_element_id = 2});
     }
