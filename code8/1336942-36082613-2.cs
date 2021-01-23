     <asp:GridView ID="GridView1"
                            OnRowDataBound="GridView1_RowDataBound"
                            AutoGenerateColumns="False"
                            runat="server">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Id"
                                    SortExpression="id" />
                                <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
