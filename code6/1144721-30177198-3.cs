    Parallel.ForEach(Sales, sale => {
    //you can clean this up using Any(), instead of Where.. 
    //Int64 rs = db.Sales_.Where(sl => sl.Serial == sale.Serial).Count();
                            if (db.Sales_.Any(sl => sl.Serial == sale.Serial))
                            {
                                return;  //ignore duplicates
                            }
                            else
                            {
                                db.Sales_.Add(sale);
                                db.SaveChanges();
                            }
    });
    return Request.CreateErrorResponse(HttpStatusCode.OK, "Finished");
    //you can just return OK considering a duplicate will not break the client.
