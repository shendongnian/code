    MyDbContext db = new MyDbContext();
    List<SelectListItem> selectedItems = new List<SelectListItem>();
    if (type == null)
    {
        return selectedItems;
    }
    var v1 = db.GetType().GetProperty(type.Name).GetValue(db, null);
    var v2 = v1.ToList().Select(ii => new SelectListItem { Text = ii.Name, Value = ii.Id.ToString() });
    if (type.Name == "class1")
    {
        v2 = v2.OrderBy(si => si.Text);
    }
    v3 = v2.ToList();
