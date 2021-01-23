      var contact = ContactInfoProvider.GetContactInfo(OnlineMarketingContext.CurrentContactID);
        if (contact != null)
        {
            // update contact
            contact.ContactFirstName = "Arnold";
            contact.SetValue("CustomField", "Value");
            // save contact
            contact.Update();
        }
