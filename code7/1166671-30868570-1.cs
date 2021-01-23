        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeContactViewModel employeecontactviewmodel)
        {
            if (ModelState.IsValid)
            {
                var employee = new EmployeeModel {
                    FirstName = employeecontactviewmodel.FirstName,
                    LastName = employeecontactviewmodel.LastName
                };
                var contact = new ContactInfoModel {
                    Data = employeecontactviewmodel.ContactInfo
                };
                db.Employee.Add(employee);
                db.Contact.Add(contact);
                db.SaveChanges();
                var contactLink = new ContactLinkModel {
                    ContactID = employee.ID,
                    ContactInfoID = contact.ID
                };
                db.ContactInfo.Add(contactLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeecontactviewmodel);
        }
