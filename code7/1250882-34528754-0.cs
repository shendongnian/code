    ContactPicker cp = new ContactPicker();
            Contact res = await cp.PickContactAsync();
            ContactStore contactStore = await ContactManager.RequestStoreAsync(ContactStoreAccessType.AllContactsReadOnly);
            Contact realContact = await contactStore.GetContactAsync(res.Id);
            
