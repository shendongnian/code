    @Html.DropDownListFor(model => model.Id_TourCategory, new SelectList(ViewBag.TourCate, "Value", "Text"))
     public ActionResult TourPackage()
        {
            List<TourCategory> lst = new List<TourCategory>();
            lst = db.TourCategories.ToList();
            ViewBag.TourCate = new SelectList(lst, "Id", "CategoryName");          
            return View();
        }
