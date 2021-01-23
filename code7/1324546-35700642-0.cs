    private static object ExecuteLock = new object();
    void Add(string type)
    {
        Task.Run(() =>
        {
            lock(ExecuteLock)
            {
                int i = db.ExecuteScalar("select coalesce(max(sequence) + 1, 1) from t1 where type='" + type + "'"); 
                db.ExecuteNonQuery("insert into t1 (type, sequence) values ('" + type + "', " + i + ")");
            }
        });
    }
    Add("B");
