    @Html.DropDownList("SubCategoryID", ViewBag.Subs, "Select an Option", new { @class = "pretty" })
    [HttpPost]
     public ActionResult Index(TestView model, string SubCategoryID)
    {
      //here you can retrieve your item from the database using the value in
      //SubCategoryID
    }
        
