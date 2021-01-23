    private async Task<Contact> SearchContactByPhoneNumberAsync(string phoneNumber)
    {
        Contact resultContact = null;
        var contactStore = await ContactManager.RequestStoreAsync(ContactStoreAccessType.AllContactsReadOnly);
        var contactReader = contactStore.GetContactReader(new ContactQueryOptions(phoneNumber));
        while (true)
        {
            var contactBatch = await contactReader.ReadBatchAsync();
            if (contactBatch.Contacts.Count > 0)
            {
                foreach (var contact in contactBatch.Contacts)
                {
                    if (contact.Phones?.Count > 0)
                    {
                        foreach (var phone in contact.Phones)
                        {
                            if (phone.Number == phoneNumber)
                            {
                                resultContact = contact;
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                break;
            }
        }
        return resultContact;
    }
