    var merchantName = INPUT_MERCHANTNAME;
    int? id = INPUT_ID;
    
    var list = dbContext.MERCHANT.AsQueryable();
    //Lets say ID is more important than name.
    if (id.HasValue) {
        list = list.Where(m => m.Id == id.Value);
    }else {
        if (!string.IsNullOrWhitespace(merchantName)) {
            list = list.Where(m => m.MerchantName == merchantName);
        }
    }
    return list.ToList();
