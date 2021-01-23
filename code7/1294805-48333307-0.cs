    @{
      var users = (IEnumerable<string>)Functions.ExecuteFunction("Custom.ActiveDirectoryUsersList");
    
      foreach (var user in users)
      {
        <span>@user</span>
      }
    }
