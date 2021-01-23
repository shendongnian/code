    if (Session["Items"] == null)
    {
        DataTable dt = (DataTable)Session["Items"];
        int count = dt.Rows.Count;
    
        if (dt.Rows.Count == 0)
        {
             lblItems.Text = "Items (0)";
        }
        else
        {
             lblItems.Text = "Items" + count;
        }
    }
