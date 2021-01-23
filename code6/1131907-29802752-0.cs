    ArrayList alList = new ArrayList();
    foreach (GridViewRow row in gvDetails.Rows)
    {
           string strID = ((Label)row.FindControl("lblID")).Text;
           string strGroup = ((Label)row.FindControl("lblGrp")).Text;
           string strValue = ((TextBox)row.FindControl("txtValue")).Text;     
           alList.Add(strID);
           alList.Add(strGroup);
           alList.Add(strValue);
    }
