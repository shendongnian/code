    var contactPicker = new ContactPicker();
    contactPicker.CommitButtonText = "Select";
    contactPicker.SelectionMode = ContactSelectionMode.Fields;
    contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);
    contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);
    
    var contacts = await contactPicker.PickContactsAsync();
    if (contacts != null && contacts.Count > 0)
    {
        foreach (Contact contact in contacts)
        {
            Debug.WriteLine(contact.DisplayName + contact.Emails[0].Address);
        }
    }
