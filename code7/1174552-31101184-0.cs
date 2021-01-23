    public partial class ThisAddIn
    {
        public Outlook.Items sentMailItems;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.ItemSend += new Microsoft.Office.Interop.Outlook.ApplicationEvents_11_ItemSendEventHandler(ItemSend);
            sentMailItems = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail).Items;
            sentMailItems.ItemAdd += new Outlook.ItemsEvents_ItemAddEventHandler(Items_ItemAdd);
        }
        void Items_ItemAdd(object item)
        {
            MessageBox.Show(((Outlook.MailItem)item).Subject);
            var msg = Item as Outlook.MailItem;
           
            string from = msg.SenderEmailAddress;
            string allRecip = "";
            foreach (Outlook.Recipient recip in msg.Recipients)
            {
                allRecip += "," + recip.Address;
            }
        }
         
        private void ItemSend(object Item, ref bool Cancel)
        {
            if (!(Item is Outlook.MailItem))
                return;
            var msg = Item as Outlook.MailItem;
            msg.DeleteAfterSubmit = false; // force storage to sent items folder (ignore user options)
            Outlook.Folder sentFolder = this.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail) as Outlook.Folder;
            if (sentFolder != null)
                msg.SaveSentMessageFolder = sentFolder; // override the default sent items location
            msg.Save();            
            
        }
        //Other auto gen code here....
    }
