    var month = 5;
    var durationByContact = from visit in visits
                            where visit.FirstSeen.Month == month
                            group visit by visit.contactId
                            into visitsByContact
                            select new
                            {
                                ContactId = visitsByContact.Key,
                                TotalDuration = visitsByContact.Sum(i => i.Duration)
                            };
