    IEnumerable<int> existingRoles = UsersExisting
        .SelectMany(u => u.AvailableRoles.Select(r => r.Serial));
    IEnumerable<int> updatingRoles = UsersToUpdate
       .SelectMany(u => u.AvailableRoles.Select(r => r.Serial));
    bool isUsersUpdated = !existingRoles.Except(updatingRoles).Any();
