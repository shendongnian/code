        IDataAccessLayer dataAccess = null;
        // container will inject data access layer
        public BusinessLayer(IDataAccessLayer dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public Data GetData()
        {
            Data data = dataAccess.GetData();
            // do something with data?
            return data;
        }
    }
    // Retruns typed data business layer
    public class DataAccessLayer : IDataAccessLayer
    {
        IDatabase db = null;
        public DataAccessLayer(IDatabase db)
        {
            this.db = db;
        }
        public Data GetData() 
        {
            var db_data = db.GetDatabaseData();
            Data data = /*convert raw db_data -> type domain data*/
            return data;
        }
    }
