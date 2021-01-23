        private void Contact_Sil()
        {
            var Eski_Contacts = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts).Items.Cast<Outlook.ContactItem>();
            while ( Eski_Contacts.Count()>0)
            {
                Eski_Contacts = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts).Items.Cast<Outlook.ContactItem>();
                foreach (var oldContact in Eski_Contacts)
                {
                    oldContact.Delete();
                }                
            }
        }
