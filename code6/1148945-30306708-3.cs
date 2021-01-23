    using (DataClasses1DataContext db = new DataClasses1DataContext(("ConnectionString")))
    {
        var ids = db.NOTIF_SCHED.Select(x=>x.NOTIF_RPT_ID.ToString()).ToArray();
        var repl = db.mainframe_replication
            .Where(mfrepl=>ids.Contains(mfrepl.RPT_ID));
    
            foreach (var mainframe_replication_data_value in repl)
            {
                Console.WriteLine("hi");
            }
        }
    }
