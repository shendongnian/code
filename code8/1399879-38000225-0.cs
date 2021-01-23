    <asp:GridView ID="gv" runat="server" OnRowDataBound="gv_RowDataBound" OnSelectedIndexChanging="gv_SelectedIndexChanging"></asp:GridView>
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType== DataControlRowType.DataRow)
    	{
    		var gv = sender as GridView;
    		var dr = e.Row.DataItem as DataRow;
    		var value = dr["Keys"] as string;
    		var lb = new LinkButton();
    		lb.CommandName = "Select";
    		lb.Text = value;
    	}
    }
    
    protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
    	// event fired after Linkbutton click
    }
