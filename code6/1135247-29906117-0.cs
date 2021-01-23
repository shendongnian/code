    do
    {
        // Start of a new batch.
        using(var db = new MyContext())
        {
            // Collect data into the context
            ...
            SaveChanges();
        }
    } while (....); // While there are new batches
