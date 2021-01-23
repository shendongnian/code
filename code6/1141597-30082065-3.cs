    var guestUsers = ...; // Wherever they're coming from
    var filteredUsers = guestUsers
            .Where(x => x.GuestDetails.Any(y => y.State != GuestGroupUserState.Deleted))
            .Select(x => new GuestUser()
                    {
                      LoginId == x.LoginId,
                      GuestDetails == x.GuestDetails
                                       .Where(y => y.State != GuestGroupUserState.Deleted)
                                       .ToList()
                    });
