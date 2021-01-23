           List<Account> ATMAccountList = new List<Account>();
            foreach (var line in File.ReadAllLines("your Path Here"))
            {
                ATMAccountList.Add(linesplitter(line));
            }
            int accountNumberInput = 123, pinInput = 6565;
            // This will be the input values from the user
            if (ATMAccountList.Where(x => x.account == accountNumberInput && x.pin == pinInput).Count() == 1)
            {
                //Proceed  with account
            }
            else
            {
                // display error ! in valid credentials
            }
