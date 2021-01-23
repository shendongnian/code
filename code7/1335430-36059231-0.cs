       var lastRecord = ds.Tables[0].Rows.LastOrDefault(r=>r["BusType"]==item.BusTypeCode);
       var lastIndex = ds.Tables[0].Rows.IndexOf(lastRecord);
       DataRow dr = ds.Tables[0].NewRow();
       dr["BusType"] = item.BusTypeCode;
       // etc.
       ds.Tables[0].Rows.InserAt(dr, lastIndex);
    }
    // insert the grand total row at the end
    return ds;
