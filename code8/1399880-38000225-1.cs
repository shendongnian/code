    <asp:GridView ID="gv" runat="server" OnRowDataBound="gv_RowDataBound" OnSelectedIndexChanging="gv_SelectedIndexChanging"></asp:GridView>
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		var gv = sender as GridView;
    		var dr = e.Row.DataItem as DataRow;
    		var value = dr["Keys"] as string;
    		var lb = new LinkButton();
    		lb.CommandName = "Select";
    		lb.Command += Lb_Command;
    		lb.Text = value;
    	}
    }
    
    private void Lb_Command(object sender, CommandEventArgs e)
    {
    	if (e.CommandName == "Select")
    	{
    		var lb = sender as LinkButton;
    		var row = lb.Parent.Parent as GridViewRow; // can be parent depends lb.Parent.Parent...
    	}
    }
    
    protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
    	// event fired after Linkbutton click
    }
