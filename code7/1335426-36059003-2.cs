    var interleaved = Interleave(query, subtotal);
    foreach (var a in interleaved)
    {
        dt = ds.Tables[0];
        dt.NewRow();
        if(String.isNullOrEmpty(a.BusName)//format your subtotal row as you like - add --rows before and after
           dt.Rows.Add(a.BusL, a.BusInterrest, a.BusAdmin, a.BusPenalty, a.TotalBusCollected ); 
       else
         dt.Rows.Add(a.BusinessTypeCode, a.BusName, a.BusL, a.BusInterrest, a.BusAdmin, a.BusPenalty, a.TotalBusCollected ); //normal row
    }
