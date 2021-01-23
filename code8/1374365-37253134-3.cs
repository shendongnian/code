    partial void Users_Updating(User entity)
    {
        if (entity.Details.Properties.Password.IsChanged)
        {
            entity.Password = YourEncryptFunction(entity.Password);
        }
    }
