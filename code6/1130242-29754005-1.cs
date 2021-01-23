    var result = db.Sales_Infoes.Where(x => x.UserName == _userName)
            .Join(db.ClientDatas,
    		x => x.Sale_Id,
    		y => y.Sale_id,
    		(x, y) => new userSales() {
                    // x is SalesInfo  obj y is ClientDatas obj do assignement here
                Name = y.Name,
                Sale_Date = y.Sale_date     
             }).ToList();
