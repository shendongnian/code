    public static List<Organization> GetByOrganizationGroupId(string organizationGroupId)
    {
        var org = new List<Organization>();
        // Retrieve the storage account from the connection string.
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
        // Create the table client.
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        // Create the CloudTable object that represents the "Organization" table.
        CloudTable organizationTable = tableClient.GetTableReference("Organization");
        // Construct the query operation for all OrganizationGroupMapping entities where PartitionKey="organizationGroupId".
        var query = new TableQuery<Organization>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, organizationGroupId));
        // Return the organizations
        return organizationTable.ExecuteQuery(query).ToList();
    }
