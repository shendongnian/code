If you're targeting .NET Core, you'll need to use the ExecuteQuerySegmentedAsync method to execute the filter condition query. ExecuteQuery is deprecated.
csharp
var cloudTableClient = _cloudStorageAccount.CreateCloudTableClient();
var myTable = cloudTableClient.GetTableReference("MyTable");
var query = new TableQuery<MyEntity>().Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, "myRowKey"));
var segment = await myTable.ExecuteQuerySegmentedAsync(query, null);
var myEntities = segment.Results;
