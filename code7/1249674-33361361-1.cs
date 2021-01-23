    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server"
            onrowdatabound="GridView1_RowDataBound">
      <Columns>    
        <asp:TemplateField HeaderText="Date">
          <ItemTemplate>
             <asp:Label ID="lblDate" Text='<%# Eval("Date") %>' runat="server"></asp:Label>
     .....
     </Columns>
    </asp:GridView>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
       {      
        var lbl =  e.Row.FindControl("lblDate") as Label;
        lbl.Text = lbl.Text.Replace("0:00:00", "");     
       }
    }
