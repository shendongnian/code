    public async void FindContacts(string searchText)
    {
        ContactStore contactStore = await ContactManager.RequestStoreAsync();
    
        IReadOnlyList<Contact> contacts = null;
    
        if(String.IsNullOrEmpty(searchText))
        { 
            // Find all contacts
            contacts = await contactStore.FindContactsAsync();
        }
        else
        {
            // Find contacts based on a search string
            contacts = await contactStore.FindContactsAsync(searchText);
        }
    
        MyContactListBox.ItemsSource = contacts;
    }
