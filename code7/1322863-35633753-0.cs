    new Thread(new ThreadStart ( delegate ()
    {
        using (var context = new MyDbContext())
        {
            var d1 = new SqlParameter("Date_From", dateFrom.ToShortDateString());
            var d2 = new SqlParameter("Date_To", dateTo.ToShortDateString());
            int result = context.Database.ExecuteSqlCommand("exec [dbo].[sproc] @Date_From, @Date_To", d1, d2);
        }
    })).Start();
