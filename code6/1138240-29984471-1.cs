    var month = 5;
    var durationsByContact = from visit in visits
                             where visit.FirstSeen.Month == month
                             group visit by visit.contactId
                             into visitsByMonth
                             select new
                             {
                                 Month = month,
                                 ContactId = visitsByMonth.Key,
                                 TotalDuration = visitsByMonth.Sum(i => i.Duration)
                             };
