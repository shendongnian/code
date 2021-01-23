    var merchantName = INPUT_MERCHANTNAME;
    int? id = INPUT_ID;
    
    var list = dbContext.MERCHANT.AsQueryable();
    if (!string.IsNullOrWhitespace(merchantName)) {
        list = list.Where(m => m.MerchantName == merchantName);
    }
    if (id.HasValue) {
        list = list.Where(m => m.Id == id.Value);
    }
    return list.ToList();
