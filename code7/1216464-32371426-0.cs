    protected void EntityDataSourceAWB_OnQueryCreated(object sender, QueryCreatedEventArgs e)
    {
        var orders = e.Query.Cast<MCustoms>();
        e.Query = from c in orders
                    where c.isDeleted == 0
                    orderby
                        (from c1 in orders
                            where
                                c1.AWB == c.AWB
                            select new
                            {
                                c1.Datetime1
                            }).Max(p => p.Datetime1) descending
                    select c;
    }
