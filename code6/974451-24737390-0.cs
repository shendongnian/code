    if (ModelState.IsValid)
    {
         client.ExtraProperty = "MyValue";
         db.Clients.Add(client);
         db.SaveChanges();
         return View(client);
    }
