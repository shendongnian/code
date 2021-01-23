    private List<IUser> MergeContactsAndUsers()
    {
        var sfContacts = SalesForceCache.Contacts.Data;
        var sfUsers = SalesForceCache.Users.Data;
        var leftJoinResults =
                sfUsers.Join(
                    sfContacts,
                    u => u.Email,
                    c => c.Email,
                    (u, c) => new ContactUser()
                    {
                        SalesForceContactId = c.SalesForceContactId,
                        SalesForceUserId = u.Id,
                        Name = u.Name,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email
                    }).ToList();
        var rightJoinResults =
            sfContacts
                .Where(c => !leftJoinResults.Select(nu => nu.SalesForceContactId).Contains(c.Id))
                .Select(c => new ContactUser
                {
                    SalesForceContactId = c.Id,
                    Name = c.Name,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email
                });
        return leftJoinResults.AddRange(rightJoinResults);
    }
