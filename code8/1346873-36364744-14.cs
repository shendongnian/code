    public static void DecryptAccounts()
    {
        //  Hmmm. What's he planning to do with this?
        Account holder = new Account(null, null, null);
        accounts.Clear();
        foreach (Account acc in Encryptedaccounts)
        {
            //  HERE IT IS. This is the same instance of holder on every
            //  iteration. After file load, every Account in accounts is the 
            //  same object as every other. 
            //  You need to create a new Account object for each account. 
            holder.username = Decrypt(acc.username, user.Decryptedpassword);
            holder.password = Decrypt(acc.password, user.Decryptedpassword);
            holder.location = Decrypt(acc.location, user.Decryptedpassword);
            accounts.Add(holder);
        }
    }
    public static void LoadFromFile()
    {
        if (File.Exists(Path.Combine(appdata, folder, file)))
        {
            Encryptedaccounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(Path.Combine(appdata, folder, file)));
        }
        DecryptAccounts();
    }
