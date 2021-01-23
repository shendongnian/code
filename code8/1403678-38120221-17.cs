    public ActionResult Index()
    {
         var model = new MyModel(){
             Id = 0,
             Name = "Your Name",
             ChkList = dbContext.myTable.Select(x => new CheckBoxListItem { ID = x.MyTableFieldID, Display = x.MyTableFieldName, IsChecked = true })
             //If you need only int part, then just avoid to bind data on Display field
         };
         return View(model);
    }
    [HttpPost]
    public ActionResult Index(MyModel myModel) //Your model object on PostAction
    {
        IEnumerable<CheckBoxListItem> ChkList = myModel.ChkList; 
        // Here is your answer, You can see all your check box items (both checked and unchecked) in ChkList, it will shows all your checked items are true and non-checked items are false in IsChecked field 
    }
