    using (var db = new ParsDatabaseContext())
    {
       var contactAttemptTest1 = _clientService.GetContactAttempt(contactAttempt.ContactAttemptId);     
       db.App_ContactAttempts.Attach(contactAttemptTest1);    
       Debug.Print(contactAttemptTest1.Ref_ContactType.Description);
    }
