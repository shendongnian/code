    List<SelectListItem> yourOptions = db.tbl_Site
        .OrderBy(p => p.SID)
        .Select(p => new SelectListItem 
        {
            Text = p.Text, //whatever field is text
            Value = p.SID.ToString() //whatever field is the value
        })
        .ToList();
    var placeHolder = new SelectListItem
    {
        Text = "--select Site--",
        Value = "0"
    };
    yourOptions.Insert(0, placeHolder);
    ViewBag.SiteTypes = yourOptions;
    
