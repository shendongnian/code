     List<AccountDetails> accountDetails = new List<AccountDetails>();
    
            //Declare class to store your info
            public class AccountDetails
            {
                public String account { get; set; }
                public String name { get; set; }
                public String pin { get; set; }
                public String check { get; set; }
                public String saving { get; set; }
            }
            
            //This function is a just an example, you need to expand it to fit your solution
            public void linesplitter(String line)
            {
                //You can place your text file reader code here. 
                //And call this function from Page_Load.
                AccountDetails dtl = new AccountDetails();
                string[] split = line.Split('*');
                dtl.account = int.Parse(info[0]);
                dtl.name = info[1];
                dtl.pin = int.Parse(info[2]);
                dtl.check = info[3];
                dtl.saving = info[4];
                
                //Every line from your text file will store to the Global List as declare in 1st line.
                accountDetails.Add(dtl);
            }
            
            //this is the function that trigger by your Button Event.
            //Pass in parameters to this function to get account details.
            //So the output for this function, something like 
            //if(result == null)
            //  login fail. etc
            public AccountDetails GetAccountDetails(String AccountNumber, String Name, String Pin)
            {
                var result = (from a in accountDetails
                              where a.account == AccountNumber
                              && a.name == Name
                              && a.pin == Pin
                              select a).FirstOrDefault();                                               
                return result;
            }
            
