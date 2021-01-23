    // set up domain context - limit to the OU you're interested in
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, null, "OU=YourOU,DC=YourCompany,DC=Com"))
    {
        // find the group in question
        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
  
        // if found....
        if (group != null)
        {
           // iterate over the group's members
           foreach (Principal p in group.GetMembers())
           {
               Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
               
               // do whatever else you need to do to those members
           }
        }
    }
