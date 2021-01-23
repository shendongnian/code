    public class DBService : IDBService
    {
        public Task Insert(RequestDetails Requestvalue)
        {
            return Task.Run(() => {
                QueueDBConnectionObject = new DBConnection(QueueDBConnectionString);
                QueueDBConnectionObject.Insert(Requestvalue);
            });
        }
     }
