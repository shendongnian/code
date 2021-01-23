      PrincipalSearchResult<Principal> users = group.GetMembers(true);
      
      UserPrincipal lastuser = (UserPrincipal)users.Last();
    
      foreach (UserPrincipal user in users)
      {
        //...
        if (user == lastuser)
        {
          // Messagebox
        }
      }
