    var JoinedCollection = from qt in QuarterTables
                           join mt in MonthTables on qt.QuarterId equals mt.QuarterId
                           join it in Items on mt.MonthId equals it.MonthId
                           select new
                           {
                               Quarter = qt.QuarterId,
                               Month = mt.MonthId,
                               Item = it.ItemId,
                               Amount = it.Amount
                           };
    
    var GroupedCollection = JoinedCollection.GroupBy(jc => new
    {
        jc.Quarter,
        jc.Month
    });
    
    var SummedCollection = GroupedCollection.Select(gc => new
    {
        Quarter = gc.Key.Quarter,
        Month = gc.Key.Month,
        Total = gc.ToList().Sum(a => a.Amount)
    });
