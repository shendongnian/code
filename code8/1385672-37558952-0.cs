    namespace ProjectedQuery
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Parse the connection string and return a reference to the storage account.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("StorageConnectionString"));
    
                // Create the table client.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
                // Create the CloudTable object that represents the "stevens" table
                CloudTable table = tableClient.GetTableReference("steventable");
    
                // Construct the projectionQuery to get only "Name" and "School"
                TableQuery<DynamicTableEntity> projectionQuery = new TableQuery<DynamicTableEntity>().Select(
                    new string[] { "Name", "School" });
    
                // Define an entiy resolver to work with the entity after retrieval
                EntityResolver<SimplePerson> resolver = (pk, rk, ts, props, etag) => new SimplePerson {
                    Name = props["Name"].StringValue,
                    School = props["School"].StringValue
                };
    
    
                foreach (SimplePerson projectedPerson in table.ExecuteQuery(projectionQuery, resolver, null, null))
                {
                    Console.WriteLine("{0}\t{1}", projectedPerson.Name, projectedPerson.School);
                }
    
                Console.Read();
            }
        }
        /// <summary>
        /// The very properties I want to retrive
        /// </summary>
        class SimplePerson
        {
            public string Name { get; set; }
            public string School { get; set; }
        }
    
        /// <summary>
        /// The entity contains all the properties
        /// </summary>
        class PersonEntity:TableEntity
        {
            public string Name { get; set; }
            public string City { get; set; }
            public string School { get; set; }
        }
    }
