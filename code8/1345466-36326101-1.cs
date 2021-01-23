     var results = from warrantyMaster in listWarrantyMasters2.Records
                      from shopInfo in listShopInfos
                           .Where(mapping => mapping.ShopCode == warrantyMaster.ShopCode )
                           .select new 
                           { 
                                ShopCode = warrantyMaster.ShopCode,
                                ATM = listWarrantyMasters2.ATM,
                                ShellNo = shopInfo.ShellNo
                           }
                           .GroupBy(x=> new { x.ShopCode, x.ShellNo })
                           .Select(x=> 
                           new{ 
                                 ShopCode = x.Key.ShopCode,
                                 ShellNo = x.Key.ShellNo,
                                 SumATM = x.Sum(item=>item.ATM)
                           });
