    var contactIds=contactList.Select(c=>c.id).ToArray();
    var objAs = jsonVals.Where(x => contactIds.Any(cid=>cid==x.ContactID) &&
                        ((x.EndDate.HasValue == false) ||
                        (x.EndDate.HasValue == true && 
                        ((x.StartDate >= startDate && x.StartDate <= endDate) || 
                        (x.EndDate.Value >= startDate 
                           && x.EndDate.Value <= endDate)))))
         .ToList();
    foreach(var contact in contactList)
    {
        var objA=objAs.Where(a=>a.ContactId==contact.id).ToList();
        ...
