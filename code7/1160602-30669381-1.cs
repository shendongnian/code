    currentItemIndex = -1;
    listView.ItemDataBound += listView_ItemDataBound;
    CheckQueryString();
    //Hide or show the table header based on id
    HtmlControl thControl = listView.FindControl("thAppend") as HtmlControl;
    if (thControl != null)
    {
        if (obj.ID == 12)
        {
            thControl.Visible = true;
        }
        else
        {
            thControl.Visible = false;
            for (int i = 0; i < listView.Items.Count; i++)
            {
                HtmlControl tdControl = listView.Items[i].FindControl("tdSchoolName") as HtmlControl;
                if (tdControl != null)
                {
                    tdControl.Visible = false;
                }
            }
                        
        }
    }
