    public long[][] GetLastMonthConsume(long metid)
    {
       var lastconsume = (from itm in db.tblMonthConsumes
                                where itm.MetID_FK == metid && itm.MonthConsumeDate ==
                                    (from itm2 in db.tblMonthConsumes
                                     where itm2.MeterID_FK == metid
                                     select itm2.MonthConsumeDate).Max()
                                select new
                                {
                                   total = (itm.MonthConsumeTotal!= null && itm.MonthConsumeTotal.HasValue) ? itm.MonthConsumeTotal.Value : 0,
                                   hour = (itm.MonthConsumeTotalFuncHour!= null && itm.MonthConsumeTotalFuncHour.HasValue) ? itm.MonthConsumeTotalFuncHour.Value : 0
                                }).ToList();
        return lastconsume.Select(t => new long[] {t.total , t.hour }).ToArray();
    }
