     List<AccountDetails> accountDetails = new List<AccountDetails>();
    
            public class AccountDetails
            {
                public String account { get; set; }
                public String name { get; set; }
                public String pin { get; set; }
                public String check { get; set; }
                public String saving { get; set; }
            }
    
            public void linesplitter(String line)
            {
                AccountDetails dtl = new AccountDetails();
                string[] split = line.Split('*');
                dtl.account = int.Parse(info[0]);
                dtl.name = info[1];
                dtl.pin = int.Parse(info[2]);
                dtl.check = info[3];
                dtl.saving = info[4];
    
                accountDetails.Add(dtl);
            }
    
            public AccountDetails GetAccountDetails(String AccountNumber, String Name, String Pin)
            {
                var result = (from a in accountDetails
                              where a.account == AccountNumber
                              && a.name == Name
                              && a.pin == Pin
                              select a).FirstOrDefault();
    
                return result;
            }
