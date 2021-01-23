    class Class1
    {
        static bool mailWasSent = false;
        private static System.Windows.Forms.ApplicationContext _context;
        static void Main(string[] args)
        {
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "My Subject";
            mailItem.To = "";
            mailItem.Attachments.Add(@"C:\test.pdf");
            mailItem.Body = "This is my Body-Text";
            mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
            ((Outlook.ItemEvents_10_Event)mailItem).Close += MailItem_onClose;
            ((Outlook.ItemEvents_10_Event)mailItem).Send += MailItem_onSend;
            //mailItem.Display(true);   // This call will make mailItem MODAL - 
            // This way, you are not allowed to create another new mail, ob browse Outlook-Folders while mailItem is visible
            // Using ApplicationContext will wait until your email is sent or closed without blocking other Outlook actions.
            using (_context = new System.Windows.Forms.ApplicationContext())
            {
                mailItem.Display();
                System.Windows.Forms.Application.Run(_context);     
            }
            if (mailWasSent)
            {
                System.Windows.Forms.MessageBox.Show("Email was sent");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Email was NOT sent");
            }
        }
        private static void MailItem_onSend(ref bool Cancel)
        {
            mailWasSent = true;
        }
        private static void MailItem_onClose(ref bool Cancel)
        {
            _context.ExitThread();
        }
    }
