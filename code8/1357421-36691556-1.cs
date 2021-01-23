     // POST: Messages/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Message message)
            {
                if (ModelState.IsValid)
                {
                    _context.Message.Add(message);
                    string PetOwner = TempData["PetOwner"].ToString();
                    string PetName = TempData["PetName"].ToString();
                    message.SentTo = PetOwner;
                    message.Subject = PetName;
                    message.DateSent = System.DateTime.Now;
                    message.SentBy = User.Identity.Name;
                    message.Read = false;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(message);
            }
