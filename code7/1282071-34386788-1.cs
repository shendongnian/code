    foreach (var userPrincipal in 
        GroupPrincipal
            .FindByIdentity(context, groupName)
            .GetMembers()
            .OfType<UserPrincipal>())
    {
        string mail = userPrincipal.EmailAddress;
        string firstName = userPrincipal.GivenName;
        string lastName = userPrincipal.Surname;
        employees.Add(
            new MPI.Domain.Entities.Users
            {
                First = firstName,
                Email = mail,
                Last = lastName
            });
    }
