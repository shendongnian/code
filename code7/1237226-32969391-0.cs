        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjectDataSource1">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Id") %>' OnClick="Button1_Click" />
            </ItemTemplate>
        </asp:Repeater>
     protected void Button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = System.Drawing.Color.Red;
        }
