    List<SelectListItem> optionList = new List<SelectListItem>
    var groups = db.MyTable.GroupBy(x => x.Category);
    foreach(var group in groups)
    {
        var optionGroup = new SelectListGroup() {Name = group.Key};
        foreach (var item in group)
        {
            optionList.Add(new SelectListItem { Value = item.ID.ToString(), Text = item.Item, Group = optionGroup });
        }
    }
