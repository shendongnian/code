    if (contacts != null && contacts.Count > 0)
    {
        try
        {
            ContactStore allAccessStore = await ContactManager.RequestStoreAsync(ContactStoreAccessType.AppContactsReadWrite);
    
            foreach (Contact contact in contacts)
            {
                var storecontact = await allAccessStore.GetContactAsync(contact.Id);
                var birthday = storecontact.ImportantDates.First(d => d.Kind ==
              ContactDateKind.Birthday);
            }
        }
        catch (Exception w)
        {
            //textBlock.Text = w.ToString();
        }
    }
