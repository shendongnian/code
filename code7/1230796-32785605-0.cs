    public void SetValue(string key, string value)
    {
        var batch = db.CreateBatch(); // You can use a transaction with CreateTransaction() if you are not in a cluster.
        batch.StringSetAsync(key, value);
        batch.SetAddAsync("to remove", key);
        batch.Execute();
    }
    public void RemoveAll()
    {
        var item = db.SetPop("to remove");
        while (item.HasValue)
        {
            db.KeyDelete(item.ToString());
            item = db.SetPop("to remove");
        }
    }
