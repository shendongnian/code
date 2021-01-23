        List<string> alList = new List<string>();
	string strID = string.Empty;
	string strGroup =  string.Empty;
	string strValue = string.Empty;
	
        foreach (GridViewRow row in gvDetails.Rows)
        {
           strID = ((Label)row.FindControl("lblID")).Text;
           strGroup = ((Label)row.FindControl("lblGrp")).Text;
           strValue = ((TextBox)row.FindControl("txtValue")).Text;     
        }
        alList.Add(strID);
        alList.Add(strGroup);
        alList.Add(strValue);
    }
    catch (Exception ex)
    {
    }
