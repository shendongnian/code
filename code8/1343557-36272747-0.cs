    using(var cxt = new YourDataBaseContext()){
        var firstJoin = from t in cxt.BookReceiptMast
                        join y in cxt.BookReceiptDtl
                             on t.BookReceiptMastId equals y.BookReceiptMastId
                         into yTemp
                        from y in yTemp.DefaultIfEmpty()
                        select new
                        {
                            Id = y != null ? y.BookMastId : 0,
                            vrsn = t.VrsnMastId
                        };
        var allTables = from p in cxt.BookMast
                        join s in firstJoin
                             on p.BookMastId equals s.Id
                             into sTemp
                        from s in sTemp
                        where s.vrsn == 2
                        select new
                        {
                            mastId = p.BookMastId
                        };
    }
