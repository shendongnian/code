      // POST: AdminUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminID,PersonName,Email,
          RoleID,ReceiveNotifications")] AdminUser adminUser, bool recNotifications = false)
        //public ActionResult Create()
        {
            //add the line below and also the extra parameter below
            adminUser.ReceiveNotifications =  reNotifications;
            if (ModelState.IsValid)
            {
                db.AdminUsers.Add(adminUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminID = new SelectList(db.AdminLogins, "AdminID", "AdminID", adminUser.AdminID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", adminUser.RoleID);
            return View(adminUser);
        }
