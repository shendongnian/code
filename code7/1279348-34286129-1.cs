    protected void rpt_Questions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          DataRowView drv = (DataRowView)e.Item.DataItem;
          Panel pnlRadio = e.Item.FindControl("pnlRadio") as Panel;
          Panel pnlText= e.Item.FindControl("pnlText") as Panel;
    if(drv["questionType"].ToString()=="choice") //or however you distinguish between the two
    { pnlRadio.Visible = True; pnlText.Visible = False;}
    else
    { pnlRadio.Visible = False; pnlText.Visible = True;
    
