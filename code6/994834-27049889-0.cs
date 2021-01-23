    var clients = db.ClientsTbls
        .Select(s => new
            {
            Text = s.FirstName + " " + s.LastName,
            Value = s.clientId
        })
        .ToList();
    ViewBag.ClientsList = new SelectList(clients, "Value", "Text");
