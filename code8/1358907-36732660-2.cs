    using (var myContext = new MyContext())
    {
        using (var transaction = myContext.Database.BeginTransaction(System.Data.IsolationLevel.Serializable))
        {
            if (!myContext.NewItems.Any(item => item.Name == identifier))
            {
                var newItem = new NewItem { Name = identifier };
                myContext.NewItems.Add(newItem);
                try
                {
                    var result = myContext.SaveChanges();
                }
    
                catch (Exception ex)
                {
                    Debug.Print(ex.ToString());
                    throw;
                }
            }
            transaction.Commit();
        }
    }
