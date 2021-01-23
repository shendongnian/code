    private readonly MyDataContext db;
    public MyClass(MyDataContext context)
    {
        db = context;
    }
    // class properties...    
    public IEnumerable<SelectListItem> MyModelFunc()
    {
        List<SelectListItem> ddlb = db.MyClass.Select(x => new SelectListItem { Value = x.ID, Text = x.name}).ToList();
        return new SelectList(ddlb , "Value", "Text");
    }
