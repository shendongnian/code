    @Html.DropDownList("SubCategoryID", ViewBag.Subs, "Select an Option", new { @class = "pretty" })
    [HttpPost]
     public ActionResult Index(TestView model, string SubCategoryID)
    {
      //here you can retrieve your item from the database using the value in
      //SubCategoryID
      //Psuedo code below:
      Subcategory test = goods.SubCategorySet.Where(sc => sc.id == SubCategoryID);
      model.SubCategory = test;
      
    }
    
