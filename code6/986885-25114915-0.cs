    ArrayList  onewayorigin = new ArrayList() ;
    ArrayList  onewaydestination = new  ArrayList() ; 
    ArrayList  onewayterminal = new ArrayList() ;
    ArrayList  onewaydeparture = new ArrayList() ;
    string strSelect;
    SqlCommand cmdSelect;
    SqlDataReader dtr;
    SqlConnection conCust;
    string connStr = ConfigurationManager.ConnectionStrings["BusConnectionString"].ConnectionString;
    conCust = new SqlConnection(connStr);
    strSelect = "Select * From Route";
    cmdSelect = new SqlCommand(strSelect, conCust);
    conCust.Open();
    dtr = cmdSelect.ExecuteReader();
    while (dtr.Read())
    {
        i = 0;
        onewayorigin.Insert(i, dtr["OneWayOrigin"].ToString());
        onewaydestination.Insert(i, dtr["OneWayDestination"].ToString());            
        onewayterminal.Insert(i, dtr["OneWayTerminal"].ToString());   
        onewaydeparture.Insert(i, dtr["OneWayDepartureTime"].ToString());   
        i++         
    }
    //to compare
    for (int iIndex = 0; iIndex < arr.Count; iIndex++)
    {
        object o = arr[iIndex];
        if (ow_terminal[iIndex].ToString().Contains(ddlterminal.SelectedValue) &&    ow_depart[iIndex].ToString().Contains(ddlDeparture.SelectedValue))
        {
            if (onewayorigin[iIndex].ToString().Contains(ddlOrigin.SelectedValue) && destination[iIndex].ToString().Contains(ddlDestination.SelectedValue))
            {
 
                lblMessage.Text = "Record exist";
                return;
            }
            else
            {
                lblMessage.Text = "No record exist";
            }
        }
        else
        {
            lblMessage.Text = "No record exist";
        }
    }
    
    
