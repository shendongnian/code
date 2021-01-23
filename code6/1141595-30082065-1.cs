    var guestUsers = ...; // Wherever they're coming from
    var filteredUsers = guestUsers.Select(
      x => new GuestUser()
           {
             LoginId == x.LoginId,
             GuestDetails == x.GuestDetails.Where(y => y.State != GuestUserState.Deleted)
                                           .ToList()
           });
