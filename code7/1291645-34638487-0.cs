    AdminLevel myFlags = AdminLevel.Partial | AdminLevel.Full;
    string s = GetAdminEmails(myFlags);
    
    public string GetAdminEmails(AdminLevel myFlags)
    {
      using (IRepository r = Rep.Renew())
      {
          string[] to = r.GetUsers().Where(u => u.AdminLevel.HasFlag(myFlags))
                                    .Select(u => u.Email).ToArray();
          return string.Join(",", to);
      }
    }
