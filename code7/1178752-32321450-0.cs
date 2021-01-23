    // Create the IFindFluent<SaleOrderModel> query.
    var collection = db.GetCollection<SaleOrderModel>("saleOrders");
    var filter = Builders<SaleOrderModel>.Filter.Eq(so => so.vendorId, 5);
    var query = collection.Find(filter);
    
    // Get the count of all docs matching the query.
    var count = await query.CountAsync();
    // Execute the query with skip and limit.
    var saleOrders = await query.Skip(20).Limit(10).ToListAsync();
    var size = saleOrders.Count();
