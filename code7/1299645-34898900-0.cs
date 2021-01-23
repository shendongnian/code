    <div>
      <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_Changed">
            <asp:ListItem Value="1">management</asp:ListItem>
            <asp:ListItem Value="2">cet</asp:ListItem>
            <asp:ListItem Value="3">comedk</asp:ListItem>
    </asp:DropDownList>
      
      <asp:TextBox ID="TextBox1" runat= "server"></asp:TextBox>
    </div>
    /*Code Behind*/
    protected void DropDownList1_Changed(object sender, EventArgs e)
    {
         if(DropDownList1.SelectedValue == "1")
            {
             TextBox1.Enabled = false;
            }
         else
            {
              TextBox1.Enabled = true;
            }
    }
