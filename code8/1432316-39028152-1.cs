        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <!-- search terms in these columns can be found -->
                <asp:BoundField DataField="field01" HeaderText="Column A" />
                <asp:BoundField DataField="field02" HeaderText="Column B" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <!-- search terms in this column cannot be found -->
                        <%# DataBinder.Eval(Container.DataItem, "field05").ToString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <!-- search terms in these columns can be found -->
                                <asp:BoundField DataField="field03" HeaderText="Column C" />
                                <asp:BoundField DataField="field04" HeaderText="Column D" />
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
