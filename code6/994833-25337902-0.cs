    var clients = (from c in db.ClientsTbls
      select new SelectListItem { 
        Text = m.FirstName + " " + m.LastName,
        Value = m.ID.ToString()
      });
    ViewBag.ClientsList = new SelectList(clients); // but better to assign this to a property in your view model
