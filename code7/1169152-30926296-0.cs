    var ProductCodes = db.tbl_ProdCodeValues.Where(x=>x.productID == _Product.productID);
    var withMatches =
     ProductCodes
     .Select(code => new {
      code,
      matches = db.InventoryCodeValues.Any(x => x.InventoryValue.ToLower().Contains(code.ProdCodeValue))
     });
