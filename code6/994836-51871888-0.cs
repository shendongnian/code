    var clients = (from c in db.ClientsTbls
      select new SelectListItem { 
        Text = m.FirstName + " " + m.LastName,
        Value = m.ID.ToString()
      });
    ViewBag.ClientsList = new SelectList(clients,"Value", "Text");
