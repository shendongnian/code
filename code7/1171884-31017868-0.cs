    public long[][] GetLastMonthConsume(long metid)
    {
       var lastconsume = (from itm in db.tblMonthConsumes
                                where itm.MetID_FK == metid && itm.MonthConsumeDate ==
                                    (from itm2 in db.tblMonthConsumes
                                     where itm2.MeterID_FK == metid
                                     select itm2.MonthConsumeDate).Max()
                                select new
                                {
                                    itm.MonthConsumeTotal,
                                    itm.MonthConsumeTotalFuncHour
                                }).ToList();
        return lastconsume.Select(t => new[] {t.MonthConsumeTotal, t.MonthConsumeTotalFuncHour}).ToArray();
    }
