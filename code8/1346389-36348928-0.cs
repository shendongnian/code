    // set up domain context - limit to the OU you're interested in
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, null, "OU=YourOU,DC=YourCompany,DC=Com"))
    {
        // find the group in question
        GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "YourGroupNameHere");
  
        // if found....
        if (group != null)
        {
           // iterate over members
           foreach (Principal p in group.GetMembers())
           {
               UserPrincipal up = p as UserPrincipal;
               
               if (up != null) 
               {
                   Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
                   // do whatever you need to do with that user principal
               }
           }
        }
    }
