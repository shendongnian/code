    class MyModel
    {
    public IEnumerable<SelectListItem> dropdowndata {get; set;}
    }
      public Actionresult MyAction(string id)
       {
         IEnumerable<data> mydata = callDALmethodtogetit();
         Mymodel model = new MyModel 
        {dropdowndata = mydata.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
       }
    @Html.DropDownListFor(model => model.dropdowndata, Model.dropdowndata)
