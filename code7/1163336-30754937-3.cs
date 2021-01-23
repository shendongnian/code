    var result = from tab in dt.AsEnumerable()
    			 group tab by tab["ApplicationNmae"]
    				 into groupDt
    				 select new
    				 {
    					 ApplicationNmae = groupDt.Key,
    					 Sum = groupDt.Sum((r) => decimal.Parse(r["Count"].ToString()))
    				 };
    
    DataTable dt1 = new DataTable();
    dt1 = dt.Clone();
    
    foreach (var item in result)
    {
    	DataRow newRow = dt1.NewRow();
    	newRow["ApplicationNmae"] = item.ApplicationNmae;
    	newRow["Count"] = item.Sum;
    	dt1.Rows.Add(newRow);
    }
    Grid.DataSource = dt1;
   
