    DataTable dt = new DataTable();
    
    dt.Columns.Add("Scheme_Code", typeof(string));
    dt.Columns.Add("Scheme_Name", typeof(string));
    dt.Columns.Add("FundFamily", typeof(string));
    dt.Columns.Add("LastDate", typeof(DateTime));
    var table = MFDatas.GroupBy(g=> new { Scheme_Code, Scheme_Name, FundFamily})
    				   .Select(s=> 
    				   { 
    						var row = dt.NewRow();
    						row["Scheme_Code"] =  s.Key.Scheme_Code, 
    						row["Scheme_Name"] = s.Key.Scheme_Name, 
    						row["FundFamily"] = s.Key.FundFamily, 
    						row["LastDate"] = s.Max(m=>m.Date) 
    					})					
    				   .OrderBy(o=>o.Field<string>("Scheme_Code"))
    				   .Distinct()
    				   .CopyToDataTable();
