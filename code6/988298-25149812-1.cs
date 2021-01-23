    //Partial View
    
    @{
    List<SelectListItem> DataItems = new List<SelectListItem>();
    using(var db = new ModelEntites()){
     foreach(var _Item in db.Table.ToList())
    {
    DataItems.add(_Item.Valriables);
    }
    ViewBag.PublicName = DataItems;
    }
    @HtmlDropDownList("PublicName");
    }
