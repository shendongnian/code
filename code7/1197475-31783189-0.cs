    protected void userID_Click(object sender, EventArgs e)
    {
        //logic to get the ClickedValue
        if(!htable.Contains(ClickedValue))
        {
    		var hTableIndex = Convert.ToInt32(ViewState["hTableIndex"]);
            htable.Add(hTableIndex++,ClickedValue);
        }
        Session["test"] = htable;
    }
