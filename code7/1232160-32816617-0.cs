    if (ListOfData.Any()) 
    { 
        grdHistoricalData.DataSource = ListOfData;
        grdHistoricalData.DataBind(); 
    } 
    else 
    { 
        // grdHistoricalData.EmptyDataText = "No Data Found!"; 
        grdHistoricalData.DataSource = new DataTable();
        grdHistoricalData.DataBind();
    }
