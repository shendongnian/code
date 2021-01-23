     public ActionResult Edit(int id)
            {
                var GetContacts = from c in db.Contacts where c.ContactID == id
                                select c;
    
                return Json(GetContacts.ToList(), JsonRequestBehavior.AllowGet);
            }
