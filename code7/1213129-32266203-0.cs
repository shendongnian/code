    public async Task AddAccount(Account accountToAdd)
    {
        //Reinitialize the vault to see if the given account is already available
        await this.InitializeSettingsService();
        Account accountFromVault = this.Accounts.FirstOrDefault(item => item.UserName.Equals(accountToAdd.UserName, StringComparison.OrdinalIgnoreCase));
                
        if(accountFromVault == null)
            _vault.Add(new PasswordCredential(Constants.VAULTRESOURCENAME, accountToAdd.UserName, accountToAdd.Password));
    
        if (accountFromVault != null && !accountFromVault.Password.Equals(accountToAdd.Password, StringComparison.Ordinal))
        {
            _vault.Remove(new PasswordCredential(Constants.VAULTRESOURCENAME, accountFromVault.UserName, accountFromVault.Password));
            _vault.Add(new PasswordCredential(Constants.VAULTRESOURCENAME, accountToAdd.UserName, accountToAdd.Password));
        }
    
        Account accountFromMemory = this.Accounts.FirstOrDefault(item => item.UserName.Equals(accountToAdd.UserName, StringComparison.OrdinalIgnoreCase));
        if (accountFromMemory != null)
        {
            if (!accountFromMemory.Password.Equals(accountToAdd.Password, StringComparison.OrdinalIgnoreCase))
            {
                this.Accounts.Remove(accountFromMemory);
                this.Accounts.Add(accountToAdd);
            }
        }
        else
            this.Accounts.Add(accountToAdd);
    }
    
    public async Task RemoveAccount(Account accountToRemove)
    {
        //Reinitialize the vault to see if the given account is already available
        await this.InitializeSettingsService();
        Account accountFromVault = this.Accounts.FirstOrDefault(item => item.UserName.Equals(accountToRemove.UserName, StringComparison.OrdinalIgnoreCase));
    
        if (accountFromVault != null)
            _vault.Remove(new PasswordCredential(Constants.VAULTRESOURCENAME, accountToRemove.UserName, accountToRemove.Password));
    
        Account accountFromMemory = this.Accounts.FirstOrDefault(item => item.UserName.Equals(accountToRemove.UserName, StringComparison.OrdinalIgnoreCase));
        if (accountFromMemory != null)
            this.Accounts.Remove(accountFromMemory);
    }
