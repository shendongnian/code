    Account curAcc = context.Accounts.FirstOrDefault(p => p.Alias == currentAlias);
    var correspondingAccount = context.Accounts.FirstOrDefault(p => p.Alias == addAlias);
    if (correspondingAccount != null)
    {
        curAcc.Addition.Contacts.Add(correspondingAccount);
    
        var existingCorrespondingAccount = curAcc.Addition
                                                 .Contacts.Where(a => a.Alias == addAlias)
                                                 .FirstOrDefault();
        if(existingCorrespondingAccount != null)
        {
              context.Accounts.Add(new Account
              {
                   AdditionID = curAcc.AdditionID,
                   Alias = curAcc.Alias,
                   ConfigID = curAcc.ConfigID,
                   IsEnabled = curAcc.IsEnabled,
                   Password = curAcc.Password,
                   Salt = curAcc.Salt
               });
        }
        context.SaveChanges();
    }
