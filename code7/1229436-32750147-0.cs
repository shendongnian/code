    <asp:Label runat="server" ID="lblMessage" />
    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="10" EmptyDataText="No Data Found" DataKeyNames="SystemId" DataSourceID="SqlDataSource1">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="ID" SortExpression="SystemId">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSystemId" runat="server" Text='<%# Eval("SystemId") />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" SortExpression="SystemName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" Text='<%# Eval("SystemName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description" SortExpression="SystemDescription">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDescription" Text='<%# Eval("SystemDescription") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Action">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnView" runat="server" CommandArgument='<%# Eval("SystemId")%>'
                                                                    ToolTip="Click to view this system" OnClick="lbtView_Click"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
    
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:YOUR-CONNECTIONSTRING-IN-WEB.CONFIG %>" SelectCommand="SELECT * FROM SYSTEM"></asp:SqlDataSource>
