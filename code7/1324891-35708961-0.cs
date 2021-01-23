    // store the accounts inside this dictionary
    var accounts = new Dictionary<string, Positions>();
    foreach(string line in lines)
    {
        Positions position = new Positions();
        string[] parsedLine = line.Split(',');
    
        position.account = parsedLine[0];
        ...
    
        Positions existingAccount;
        // if the account already exists in the dictionary
        if (accounts.TryGetValue(position.account, out existingAccount)) {
            existingAccount.buy += position.buy;
            // do updating logic here
        } else {
            accounts.add(position.account, position);
            // otherwise add it as a new element
        }
    }
