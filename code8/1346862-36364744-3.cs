    public Account DecryptAccount(Account acc)
    {
        return new Account {
            username = Decrypt(acc.username, user.Decryptedpassword),
            password = Decrypt(acc.password, user.Decryptedpassword),
            location = Decrypt(acc.location, user.Decryptedpassword)
        };
    }
    public static void DecryptAccounts()
    {
        accounts.Clear();
        foreach (Account acc in Encryptedaccounts)
        {
            accounts.Add(DecryptAccount(acc));
        }
    }
