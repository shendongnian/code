    DateTime stDate =  dt.AsEnumerable()
                         .Max(r => Convert.ToDateTime(r.Field<string>("date")));
    
    DateTime eDate =  dt.AsEnumerable()
                         .Min(r => Convert.ToDateTime(r.Field<string>("date")));
