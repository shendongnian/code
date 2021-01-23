    IEnumerable<Contact> contacts = GetAllContacts();
    ConcurrentDictionary<string, IReadOnlyList<Contact>> dict = new ConcurrentDictionary<string, IReadOnlyList<Contact>>();
    foreach (IGrouping<string, Contact> group in contacts.GroupBy(c => c.COMPANY_ID))
    {
        if (!dict.TryAdd(group.Key, group.ToArray())) {
            throw new InvalidOperationException("Key already added.");
        }
    }
