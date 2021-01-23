    using (DataClasses1DataContext db = new DataClasses1DataContext(("ConnectionString")))
    {
        var as = db.NOTIF_SCHED.Select(x=>x.NOTIF_RPT_ID).ToArray();
        var repl = db.mainframe_replication
            .Where(mfrepl=>as.Contains(mfrepl.RPT_ID));
    
            foreach (var mainframe_replication_data_value in repl)
            {
                Console.WriteLine("hi");
            }
        }
    }
