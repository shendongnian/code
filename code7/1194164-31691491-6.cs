     public static void removeContact(List<Contact> contactList, object ContactName)
            {
                Contact contactToRemove = (Contact)contactList.AsEnumerable().Where
                                          (x => x.ContactName == ContactName || 
                                           x.ContactNumber == (int)ContactName).First();
                contactList.Remove(contactToRemove);
            }
