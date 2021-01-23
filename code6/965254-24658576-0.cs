    using (var tra = cn.BeginTransaction())
    {
        try
        { 
            foreach(var myQuery in myQueries)
            { 
                using (var cd = new SQLiteCommand(myQuery, cn, tra))
                {
                    cd.ExecuteNonQuery();
                }
            }
            tra.Commit();
        }
        catch(Exception ex)
        {
            tra.Rollback();
            Console.Error.Writeline("I did nothing, because something wrong happened: {0}", ex);
            throw;
        }
    }
