    public ActionResult Stuff(){
        List<MyApiModel> items = db.MyEntityFrameworkClass.Select(x=>new MyApiModel{
              //Notice I am not setting the isvalid property
              //Its computed, class takes care of returning proper value
              Name = x.MyNameColumn, 
              SomethingElse = x.MyOtherColumn
        }.ToList();
        Return Json(items);
    }
