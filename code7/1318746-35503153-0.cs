    var dtData1 = datatable1.AsEnumerable().Select(a => new { ColValue = a["SomeCol"].ToString() });
    var dtData2 = datatable2.AsEnumerable().Select(a => new { ColValue = a["SomeCol"].ToString() });
    
    var exceptXY = dtData1.Except(dtData2);
    
    DataTable dtMisMatch = (from a in datatable1.AsEnumerable() 
                           join xy in exceptXY on a["SomeCol"].ToString() equals ab.ColValue select a).CopyToDataTable();
