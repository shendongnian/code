    public ActionResult GetDropDownList()
            {
                List<SelectListItem> dropDownList= new List<SelectListItem>();
                using (var context = new assessmentEntities())
                {
                     //getting data from the DB
                   var result = context.getDataFromDB().toList();
                   
                    foreach (var item in result)
                    {
                        dropDownList.Add(new SelectListItem() { Text = item.Variable1, Value = item.Variable2});
                    }
                    ViewBag.DropDownData = dropDownList;
                }
        return View();
            }`
 
