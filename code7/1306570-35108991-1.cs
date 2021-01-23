    Dim query As New ContactsQuery(ContactsQuery.CreateContactsUri("default"))
    query.NumberToRetrieve = 2000
    query.OrderBy = ContactsQuery.OrderByLastModified
    query.SortOrder = ContactsQuery.SortOrderDescending
    query.Group = GroupAtomId
    
    Dim f As Feed(Of Contact) = cr.Get(Of Contact)(query)
    
    For Each entry As Contact In f.Entries
     'Do something with the data, these are real contacts in GMail
    Next
