      var user = Environment.UserDomainName + "\\" + Environment.UserName;
      var rs = new RegistrySecurity();
      rs.AddAccessRule(new RegistryAccessRule(user,
        RegistryRights.ReadKey | RegistryRights.Delete | RegistryRights.WriteKey,
        InheritanceFlags.None,
        PropagationFlags.None,
        AccessControlType.Allow));
      var lo1 = Registry.CurrentUser.CreateSubKey(KEY_NAME, RegistryKeyPermissionCheck.Default, rs);
