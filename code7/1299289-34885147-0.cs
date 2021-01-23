    public class Functions
    {
        public static void ProcessTimer([TimerTrigger("0 0 9 1/1 * ? *", RunOnStartup = true)]
        TimerInfo info)
        {
            var remCheckOuts = // query code here                                
         into grouped
         select new Reminder
         {
              /// populate viewmodel 
         });    
    
        // send emails
        foreach (var i in remCheckOuts)
        {
                    string Full = i.Full;
                    string FirstName = i.FirstName;
                    var CheckOutCt = i.CheckOutCt;                   
    
                    dynamic email = new Email("emReminder");
                    email.FromAdd = "test@test.com";
                    email.To = "test2@test2.com";
                    email.NPFirstName = NPFirstName;
                    email.CheckOutCt = CheckOutCt;
                    email.Send();
          } 
        }
    }
