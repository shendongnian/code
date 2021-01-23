            public static void SendEmailtoContacts()
            {
                string subjectEmail = "test results ";
                string bodyEmail = "test results";
                Microsoft.Office.Interop.Outlook.Application appp = new  
                Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MAPIFolder sentContacts = 
                appp.ActiveExplorer().Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.O    lDefaultFolders.olFolderContacts);
    
                foreach (Outlook.ContactItem contact in sentContacts.Items)
                {
                    if (contact.Email1Address.Contains("gmail.com"))
                    {
                        CreateEmailItem(subjectEmail, contact.Email1Address, bodyEmail);
                    }
                }
            }
    
            public static void CreateEmailItem(string subjectEmail,string toEmail, string bodyEmail)
            {
                Microsoft.Office.Interop.Outlook.Application app = new  
                Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem eMail = 
                app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
    
                eMail.Subject = subjectEmail;
                eMail.To = toEmail;
                eMail.Body = bodyEmail;
                eMail.Importance = Outlook.OlImportance.olImportanceLow;
                ((Outlook._MailItem)eMail).Send();
            }
   
