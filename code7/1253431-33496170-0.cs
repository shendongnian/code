        Microsoft.Office.Interop.Outlook.Items OutlookItems;
        Microsoft.Office.Interop.Outlook.Application outlookObj;
        MAPIFolder Folder_Contacts;
        private void Form1_Load(object sender, EventArgs e)
        {
            outlookObj = new Microsoft.Office.Interop.Outlook.Application();
            Folder_Contacts = (MAPIFolder)outlookObj.Session.GetDefaultFolder(OlDefaultFolders.olFolderContacts);
            OutlookItems = Folder_Contacts.Items;
            for (int i = 0; i < OutlookItems.Count; i++)
            {
                Microsoft.Office.Interop.Outlook.ContactItem contact = (Microsoft.Office.Interop.Outlook.ContactItem)OutlookItems[i + 1];
          MessageBox.Show("FirstName:"contact.FirstName +" "+"LastName:"+contact.LastName +" "+"Emailid:"+contact.Email1Address);  
      }
    }
