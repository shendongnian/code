    var SummedCollection = from qt in QuarterTables
                           join mt in MonthTables on qt.QuarterId equals mt.QuarterId
                           join it in Items on mt.MonthId equals it.MonthId
                           group new
                           {
                               Quarter = qt.QuarterId,
                               Month = mt.MonthId,
                               Item = it.ItemId,
                               Amount = it.Amount
                           }
                           by new
                           {
                               qt.QuarterId,
                               mt.MonthId
                           } into gc
                           select new
                           {
                               Quarter = gc.Key.QuarterId,
                               Month = gc.Key.MonthId,
                               Total = gc.ToList().Sum(a => a.Amount)
                           };
