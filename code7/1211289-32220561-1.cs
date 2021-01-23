     <asp:GridView id="UserGrid" runat="server"
                    CellPadding="2" CellSpacing="1"
                    Gridlines="Both" AutoGenerateColumns="false">
          <Columns>
            <asp:BoundColumn DataField="UserName" ReadOnly="False" HeaderText="Name" />
            <asp:BoundColumn DataField="Email" ReadOnly="True" HeaderText="Email" />
            <asp:BoundColumn DataField="LastActivityDate" ReadOnly="True" HeaderText="Last activity"/>
            <asp:TemplateField HeaderText="User Roles" ItemStyle-Width="30%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrole" runat="server" %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="darkblue" ForeColor="white" />
        
        </asp:DataGrid>
    protected void UserGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    e.Row.FindControl("lblrole").Text='your user role';
    }
