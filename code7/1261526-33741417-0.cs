    var contact db.Contacts.AsEnumerable()
                    .Where(contact => contact.AreaCode == textmessage.EnteredPrefix && contact.PhoneNumber == textmessage.EnteredPhoneNumber);
    
    if(contact != null && contact.Any())
    {
       ViewData["Contact"] = contact.FirstOrDefault();
       db.Textmessages.Add(textmessage);
       db.SaveChanges();
       return RedirectToAction("Details", textmessage );
    }
    
    and then in the view you can read it back:
    
    @{
        var contact = (Contact)ViewData["Contact"];
    }
