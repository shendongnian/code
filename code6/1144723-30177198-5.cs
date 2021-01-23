    Parallel.ForEach(Sales, sale => {
    //you can clean this up using Any(), instead of Where.. 
    //Int64 rs = db.Sales_.Where(sl => sl.Serial == sale.Serial).Count();
        using (var dbContext = new YourDatabaseContext())
        {
                            if (dbContext .Sales_.Any(sl => sl.Serial == sale.Serial))
                            {
                                return;  //ignore duplicates
                            }
                            else
                            {
                                dbContext .Sales_.Add(sale);
                                dbContext .SaveChanges();
                            }
        }
    });
    return Request.CreateErrorResponse(HttpStatusCode.OK, "Finished");
    //you can just return OK considering a duplicate will not break the client.
