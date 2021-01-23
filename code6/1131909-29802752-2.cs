    string strID = null, strGroup = null, strValue = null;
    var alList = new List<string>();
    foreach (GridViewRow row in gvDetails.Rows)
    {
           strID = ((Label)row.FindControl("lblID")).Text;
           strGroup = ((Label)row.FindControl("lblGrp")).Text;
           strValue = ((TextBox)row.FindControl("txtValue")).Text;     
    }
    alList.Add(strID);
    alList.Add(strGroup);
    alList.Add(strValue);
    
       
