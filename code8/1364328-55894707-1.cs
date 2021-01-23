    var dbtables = new OtherContext();
    string userId = User.Identity.GetUserId().ToString();
    ListData listdata = new ListData();
    var list1 = dbtables.EntityFrameworkModel1.ToList()
                .Where(c => c.OwnerId == userId && c.Active == true)
                .OrderBy(c => c.DateAdded).Reverse();
    ListData.List1 = list1;
..
    return View(listdata);
