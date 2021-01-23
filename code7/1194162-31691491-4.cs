     public static void removeContact(List<Contact> contactList, string  ContactName)
            {
                Contact contactToRemove = (Contact)contactList.AsEnumerable().Where(x => x.ContactName == ContactName).First();
                contactList.Remove(contactToRemove);
            }
