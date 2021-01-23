      PrincipalSearchResult<Principal> users = group.GetMembers(true);
      
      Principal lastuser = users.Last();
    
      foreach (UserPrincipal user in users)
      {
        //...
        if (user == lastuser)
        {
          // Messagebox
        }
      }
