            Command AddPermissions = new Command("Add-MailboxPermission");
            AddPermissions.Parameters.Add("Identity", Mailbox);
            AddPermissions.Parameters.Add("User", UserName);
            AddPermissions.Parameters.Add("AccessRights", "FullAccess");
            AddPermissions.Parameters.Add("AutoMapping", false);
