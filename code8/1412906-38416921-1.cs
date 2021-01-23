    using (Rfc2898DeriveBytes verifier = new Rfc2898DeriveBytes(
        inputPassword,
        loadedProfile.Salt,
        YourSystemConfiguration.GetIterationCount(loadedProfile.PasswordSettingsVersion)))
    {
        byte[] verifyBytes = registerer.GetBytes(loadedProfile.PasswordVerify.Length);
        if (!ConstantTimeEquals(verifyBytes, loadedProfile.PasswordVerify))
        {
            return false;
        }
        if (loadedProfile.PasswordSettingsVersion < YourSystemConfiguration.GetIterationCount(exportPasswordSettingsVersion))
        {
            // Re-derive their password and save it with your newer (stronger, presumably) cryptographic settings.
        }
        return true;
    }
