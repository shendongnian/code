    public Organisation()
    {
        this.Permissions = new UserPermissions();
        if (this.Id == 0) // new object not yet persisted
        {
            this.Permissions.Contacts = PermissionLevel.Locked;
            // etc
        }
    }
