    public class DBService : IDBService
    {
        public Task Insert(RequestDetails Requestvalue)
        {
            return Task.Start(() => {
                QueueDBConnectionObject = new DBConnection(QueueDBConnectionString);
                QueueDBConnectionObject.Insert(Requestvalue);
            });
        }
     }
