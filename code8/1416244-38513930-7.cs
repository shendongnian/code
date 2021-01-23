    public ActionResult AddPhone(int ContactId)
    {
        var newPhone = new Phone();
        Contact ct = ctx.Contacts.Find(ContactId);
        ct.Phones.Add(newPhone);
        ctx.SaveChanges();
        return View(newPhone);
    }
