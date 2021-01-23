    using Outlook = Microsoft.Office.Interop.Outlook;
     
     private void SendWithExchange()
                {
        
                    Outlook.Application oApp = new Outlook.Application();
                    Outlook.MailItem mail = oApp.CreateItem(
                        Outlook.OlItemType.olMailItem) as Outlook.MailItem;
                    mail.Subject = "Exemple à tester";
                    Outlook.AddressEntry currentUser =
                        oApp.Session.CurrentUser.AddressEntry;
                    if (currentUser.Type == "EX")
                    {
                        Outlook.ExchangeUser manager =
                            currentUser.GetExchangeUser();
                        mail.Recipients.Add(manager.PrimarySmtpAddress);
                        mail.Recipients.ResolveAll();
                        //mail.Attachments.Add(@"c:\sales reports\fy06q4.xlsx",
                        //    Outlook.OlAttachmentType.olByValue, Type.Missing,
                        //    Type.Missing);
                        mail.Send();
                    }
                }
