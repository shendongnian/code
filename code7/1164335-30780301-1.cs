    groupNameToSearchFor = "Administrators"; // can be any group,maybe better to use something like builtin.administrators
    using (PrincipalContext pc = new PrincipalContext(ContextType.Machine, null))
     {
            ManagementObjectSearcher usersSearcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_UserAccount");
            ManagementObjectCollection users = usersSearcher.Get();
            foreach (ManagementObject user in users)
            {
                if ((bool)user["LocalAccount"] == true && int.Parse(user["SIDType"].ToString()) == 1)
                {
                    var userPrincipal = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, user["Name"].ToString());
                    GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, groupNameToSearchFor );
                    MessageBox.Show("Is User admin? -> " (bool)userPrincipal.IsMemberOf(gp));
                        }
                    }
                }
     }
