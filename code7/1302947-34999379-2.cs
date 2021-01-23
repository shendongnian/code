    public ActionResult Stuff(){
        List<MyApiModel> items = db.MyEntityFrameworkClass.Select(x=>new MyApiModel{
              Name = x.MyNameColumn, 
              SomethingElse = x.MyOtherColumn
        }.ToList();
        Return Json(items);
    }
