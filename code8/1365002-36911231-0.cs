        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1"
                            OnCheckedChanged="CheckBox1_Click"
                            AutoPostBack="True" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
