    private static void Add(IEnumerable<UserPrincipal> users)
    {
        var machineContext = new PrincipalContext(ContextType.Machine, "ABCDEFGHI1",
           null, ContextOptions.Negotiate, "c123789", "test123");
        var group = GroupPrincipal.FindByIdentity(machineContext,"Administrators"); 
        foreach(var user in users)
        {
            group.Members.Add(user); 
        }
        Console.WriteLine("saving group");
        group.Save();
    }
