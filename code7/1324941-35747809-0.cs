        var database = this.client.GetServer().GetDatabase("A_Database");
        var collection = database.GetCollection<object>("A_Collection");
        try
        {
            collection.Insert(new { Id = paymentReference.ToGuid() });
        }
        catch (Exception)
        {
            collection.Insert(new { Id = Guid.NewGuid(); });
            return tru;
        }
        return true;
