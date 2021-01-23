    var query = from im in listWarrantyMasters2.Records
                join s in listShopInfos
                on im.ShopCode equals s.ShopCode
                group im by new { s.ShopCode, s.CellNo } into g
                select new
                {
                    g.Key.ShopCode,
                    g.Key.CellNo,
                    SumAmt = g.Sum(e => e.Amt)
                };
