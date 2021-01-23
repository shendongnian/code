    DataTable ds = new DataTable();
    List<int> curveIds = new List<int>() {1,2,3,4};
    public void Test()
    {
        LoadDs();
        List<object> endress = new List<object>();
        //filter all timestamps, getting only the date info
        var timeStamps = ds.AsEnumerable().Select(r=> ((DateTime)r["Timestamp"]).Date).Distinct();
        //for each id
        foreach (var timeStamp in timeStamps)
        {
            //find all the same timestamp (on the same day)
            var listSameTimestamp = ds.AsEnumerable().Where(r => ((DateTime)r["Timestamp"]).Date == timeStamp);
            var listIds = listSameTimestamp.Select(r => (int)r["curveID"]).Distinct();
            //ensure they all have the curveIDs you are looking for
            var haveThemAll = curveIds.Intersect(listIds).Count() == curveIds.Count();
                                            
            if (haveThemAll == false)
                continue;
            //find the lowest timestamp
            var rowFound = listSameTimestamp.OrderBy(r => (DateTime)r["Timestamp"]).FirstOrDefault();
            if (rowFound == null)
                continue;
            //create an anonymous object (coud not understand your needs)
            endress.Add(new
            {
                Timestamp = (DateTime)rowFound["Timestamp"],
                Spread = (double)rowFound["mid"] - 0.4 * (double)rowFound["mid"],
                Power = (double)rowFound["mid"]
            });                   
        }
        foreach (var o in endress)
        {
            Console.WriteLine(o);
        }
    }
    public void LoadDs()
    {
        ds = new DataTable();
        ds.Columns.Add("curveID",typeof(int));
        ds.Columns.Add("Timestamp", typeof(DateTime));
        ds.Columns.Add("mid", typeof(double));
        
        for (int i = 0; i < 50000; i++)
        {
            Random rand = new Random(i);
            var row = ds.NewRow();
            row["curveID"] = rand.Next(1,5);
            row["Timestamp"] = new  DateTime(2016,4, rand.Next(1,5), rand.Next(1,3), 0,0);
            row["mid"] = rand.NextDouble();
            ds.Rows.Add(row);
        }
    }
