    var allSpMembers = GetSpList(); // get your members as you mentioned before by `.Cast<SPListItem>()`
    List<SPListItem> spMembers =
        dbMembers.GroupJoin(allSpMembers, dbM => dbM.Email, spM => spM.Email,
            (dbMember, spMember) => new { dbMember, spMember })
                 .SelectMany(x => x.spMember.DefaultIfEmpty(), (x, spMember) =>
                     {
                         SPListItem yourSpListItem;
                         if (spMember != null)
                         {
                             yourSpListItem = spMember;
                         }
                         else
                         {
                             yourSpListItem = x.dbMember; //make some mapping here to SPListItem model
                         }
                         yourSpListItem.VIP = true;
                         return yourSpListItem;
                     }).ToList();
