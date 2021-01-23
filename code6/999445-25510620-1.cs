    //using Microsoft.Office.Interop.Outlook;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Office.Interop.Outlook;
    
    
    namespace ConsoleApplication1
    {
        
        using Outlook = Microsoft.Office.Interop.Outlook; 
        
        public static class Program
        {
            static void Main(string[] args)
            {
    
                SendUsingAccountExample();
            }
    
    
            private static void SendUsingAccountExample()
            {
                var application = new Application();
                var mail = (_MailItem)application.CreateItem(OlItemType.olMailItem);
                mail.Body = "Hello";
                mail.Subject = "Good Bye";
                mail.To = "hello@google.com";
                // Next 2 lines are optional. if not specified, the default account will be used
                Outlook.Account account = Application.Session.Accounts["MyOtherAccount"];
                mail.SendUsingAccount = account;
               
                mail.Display(false); // To Display
                //mail.Send(); // To Send
    
            }
    
        }
    }
