      public class ChatMessage : TableEntity
      {
         public ChatMessage() { }
         public ChatMessage(string user, string time, string message)
         {
            PartitionKey = user;
            RowKey = time;
            Message = message;
         }
         public string SessionID { get; set; }         
         public string Message { get; set; }         
      }
      static void Main(string[] args)
      {
         string storageConnection = "DefaultEndpointsProtocol=https;AccountName=mygames;AccountKey=ADD_YOUR_KEY_HERE";
         // Select table
         CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnection);
         CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
         CloudTable table = tableClient.GetTableReference("chatmessages");
         table.CreateIfNotExists();
         // Add a chat messages
         ChatMessage msg1 = new ChatMessage("mimyrah", "150816_17:01:00", "What's up?");
         table.Execute(TableOperation.InsertOrReplace(msg1));
         ChatMessage msg2 = new ChatMessage("timarshal", "150816_17:02:00", "Not much.");
         table.Execute(TableOperation.InsertOrReplace(msg2));
         ChatMessage msg3 = new ChatMessage("mimyrah", "150816_17:02:30", "Cool.");
         table.Execute(TableOperation.InsertOrReplace(msg3));        
         // Query the messages created between 17:00 and 18:00
         string pkFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "mimyrah");
         string rowKeyLower = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, "150816_17");
         string rowKeyUpper = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.LessThanOrEqual, "150816_18");
         string rkFilter = TableQuery.CombineFilters(rowKeyLower, TableOperators.And, rowKeyUpper);
         string combinedFilter = TableQuery.CombineFilters(pkFilter, TableOperators.And, rkFilter);
         TableQuery<ChatMessage> query = new TableQuery<ChatMessage>().Where(combinedFilter);
         var list = table.ExecuteQuery(query).ToList();
         foreach (ChatMessage entity in list)
         {
            Console.WriteLine("[" + entity.RowKey + "] " + entity.PartitionKey + ": " + entity.Message);
            // [150816_17:01:00] mimyrah: "What's up?"
            // [150816_17:02:30] mimyrah: "Cool"
         }
         Console.ReadKey();
}
}
 
