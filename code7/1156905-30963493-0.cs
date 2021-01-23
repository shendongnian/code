    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
                <asp:Label ID="lblid" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Details">
            <ItemTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView2_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="Panel3" runat="server" GroupingText="یاد داشت">
                                                <asp:TextBox ID="TextBoxDescription" runat="server" Style="resize: none; width: 612px; height: 160px;"
                                                    Text='<%# Eval("UserDescription") %>' TextMode="MultiLine"></asp:TextBox>
                                                <br />
                                                <br />
                                                <asp:LinkButton ID="LinkButtonSave" CommandName="updateData" CommandArgument='<%#Eval("ReportId") %>' runat="server">ذخیره</asp:LinkButton>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
