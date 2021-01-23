    static YourClassName()
    {
        _administratorsGroup = Task.Run(() =>
        {
            var machineContext = new PrincipalContext(ContextType.Machine, "ABCDEFGHI1",
               null, ContextOptions.Negotiate, "c123789", "test123");
            return GroupPrincipal.FindByIdentity(machineContext,"Administrators"); 
        });
    }
    private static Task<GroupPrincipal> _administratorsGroup;
    
    private static void Add(UserPrincipal user)
    {
        group = _administratorsGroup.Result;
        lock(group)
        {
            group.Members.Add(user); 
        
            Console.WriteLine("saving group");
            group.Save();
        }
    }
