    if (option == "FirstName")
    { 
        var days = Convert.ToInt32(date) * -1;
        if(days > 0)
        {
            DateTime today = DateTime.Now.AddDays(days);
            return View(db.Orders.Where(x => x.FirstName.StartsWith(search) && x.OrderDate >= today || search == null).ToList());
        }
        else
        {
             return View(db.Orders.Where(x => x.FirstName.StartsWith(search) || search == null).ToList());
        }
    }
