           List<Account> ATMAccountList = new List<Account>();
            foreach (var line in File.ReadAllLines("your Path Here"))
            {
                ATMAccountList.Add(linesplitter(line));
            }
             int accountNumberInput = 123, pinInput = 6565;
            // This will be the input values from the user
             bool matchFound = false;
            foreach (var accountItem in ATMAccountList)
            {
                if (accountItem.account == accountNumberInput && accountItem.pin == pinInput)
                {
                    matchFound = true;
                    break;
                }
            }
            if (matchFound)
            {
                //Proceed  with account
            }
            else
            {
                // display error ! in valid credential
            }          
          
