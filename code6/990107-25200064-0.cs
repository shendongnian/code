          var SubQuery = from Contacts in db.Contacts
                           from ContactAddictions in db.ContactAddictions.DefaultIfEmpty()
                           from ContactTreatmentPreferences in db.ContactTreatmentPreferences.DefaultIfEmpty()
                           from TreatmentHistories in db.TreatmentHistories.DefaultIfEmpty()
                           orderby
                               Contacts.LastName, Contacts.FirstName
                           where
                                Contacts.ID == ID
                           select Contacts;
            var Query = SubQuery.Include("ContactAddictions")
                .Include("ContactTreatmentPreferences")
                .Include("ContactAddictions.Tag")
                .Include("ContactTreatmentPreferences.Tag")
                .Include("TreatmentHistories")
                .Include("TreatmentHistories.TreatmentCenter")
                .Include("ContactDispositionType")
                .Include("State");
            return Query.FirstOrDefault();
