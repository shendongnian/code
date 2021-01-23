    public JsonResult GetPhoneNoByContactPersonID(Guid CustomerContactId)
    {
        var resultMobileNumber = string.Empty;
    
        var ContactID = db.CustomerContacts.Where(i => i.CustomerContactID == CustomerContactId).Select(i => i.ContactID).FirstOrDefault();
        if(ContactID != null)
        {
    	var contact = (from pn in db.Contacts where pn.ContactID == ContactID select pn).FirstOrDefault();
    	// check if contact is found
            if (contact != null)
    	{
    		// if mobile 1 has value
    		if(string.IsNullOrEmpty(contact.Mobile1) == false)
    		{
    			resultMobileNumber  = contact.Mobile1;
    		}
    		else if(string.IsNullOrEmpty(contact.Mobile2) == false)
    		{
    			resultMobileNumber  = contact.Mobile2;
    		}
    	}
        }
         
        return Json(resultMobileNumber, JsonRequestBehavior.AllowGet);
    }
