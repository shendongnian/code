    using (var context = new MyDbContext())
    {
        context.ExecuteStoreCommand("Update MyTable Set Value = {0} Where SomeColumn = {1}", 
                                    updateValue, queryValue);
        context.ExecuteStoreCommand("Delete From MyTable Where value = {0}", 
                                    myValueToQueryBy);
    }
