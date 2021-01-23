    public IEnumerable<JObject> Get()
    {
        // Create the table client.
        var tableClient = _account.CreateCloudTableClient();
        // Retrieve a reference to the table.
        var contactsTable = tableClient.GetTableReference("contacts");
        // Create the table if it doesn't exist.
        contactsTable.CreateIfNotExists();
        // Construct the query operation for all contact entities
        var query = new TableQuery<ContactEntity>();
        var items = contactsTable.ExecuteQuery<ContactEntity>(query).ToList();
        return items.Select(i => i.ToJson());
    }
