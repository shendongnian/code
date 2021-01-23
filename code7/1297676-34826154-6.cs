    lamiEntities1 lam = new lamiEntities1();
        var query =( from sls in lam.sales.Include("item")
        			orderby sls.Id descending
                    select new
                    {
                        ItemName = sls.Item.ItemName,
                        TotalAmounts = sls.Amount,
                        Remarks=sls.Remarks,
                        Dates = sls.Date
                    }).Take(20);
