        public List<Contact> GetSuggestedContacts()
        {
            // Instantiate the item view with the number of items to retrieve from the Contacts folder.
            ItemView view = new ItemView(1000);
            // To keep the request smaller, request only the display name property.
            view.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties, ContactSchema.DisplayName, ContactSchema.Surname, ContactSchema.GivenName, ContactSchema.EmailAddress1);
            // Retrieve the RecipientCache folder in the Contacts folder that have the properties that you selected.
            var contactFolders = _service.FindFolders(new FolderId(WellKnownFolderName.Root), new FolderView(500));
            var folder = contactFolders.Folders.SingleOrDefault(x => x.DisplayName == "AllContacts");
            if(folder == null) return new List<Contact>();
            //Cast Item in Contact and filtered only real adresses
            var cacheContacts = folder.FindItems(view).Items.OfType<Contact>().Where(x => x.EmailAddresses.Contains(0) && x.EmailAddresses[0].Address != null && x.EmailAddresses[0].Address.Contains('@')).ToList();
            return cacheContacts;
        }
