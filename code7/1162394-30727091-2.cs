    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "false" 
        OnRowCommand = "OnRowCommand">
     <Columns>
      <asp:ButtonField CommandName = "ButtonField"  DataTextField = "CustomerID"
            ButtonType = "Button"/>
     </Columns>
    </asp:GridView>
    
    protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow gvRow = GridView1.Rows[index]; 
    }
