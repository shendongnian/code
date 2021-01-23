            // Load the hive
            var principalContext = new PrincipalContext(ContextType.Machine);
            var standardUser = UserPrincipal.FindByIdentity(principalContext, "newuser");
            var sid = standardUser.Sid.ToString();
            StringBuilder path = new StringBuilder(4 * 1024);
            int size = path.Capacity;
            GetProfilesDirectory(path, ref size);
            var filename = Path.Combine(path.ToString(), "newuser", "NTUSER.DAT");
            Thread.Sleep(2000);
            int retVal = RegLoadKey(HKEY_USERS, sid, filename);
