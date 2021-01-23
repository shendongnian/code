    public static void OnEmailHyperlinkClick(object sender, RoutedEventArgs e)
            {
                try
                {
                    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
    
                    MailItem msg = (MailItem)oApp.CreateItem(OlItemType.olMailItem);
    
                    msg.Subject = "My subject";
    
                    msg.Body = "My Message Body";
    
                    Recipients recipients = (Recipients)msg.Recipients;
    
                    Recipient recipient = (Recipient)recipients.Add("someone@test.com");
                    recipient.Resolve();
    
                    msg.Display(); // If you want to have the email displayed for the user to send
                    // Otherwise
                    msg.Send();
    
                    recipient = null;
                    recipients = null;
                    msg = null;
                    oApp = null;
                }
                catch (Exception ex)
                {
                    
                }
            }
