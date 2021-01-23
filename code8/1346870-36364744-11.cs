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
    //  You've got the same issue here
    private static void EncryptAccounts()
    {
        Encryptedaccounts.Clear();
        foreach (Account acc in accounts)
        {
            Encryptedaccounts.Add(EncryptAccount(acc));
        }
    }
    public Account EncryptAccount(Account acc)
    {
        return new Account {
            username = Encrypt(acc.username, user.Decryptedpassword),
            password = Encrypt(acc.password, user.Decryptedpassword),
            location = Encrypt(acc.location, user.Decryptedpassword)
        };
    }
