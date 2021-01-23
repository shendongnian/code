        <asp:GridView>
            <Columns>
                <asp:TemplateField HeaderText="Test">
                    <ItemTemplate>
                        <asp:Button ID="btnTest" CommandArgument='btnTest' runat="server" Text="Test et" OnClick="btnTest_Click" />
                        <asp:Button ID="btnVerify" CommandArgument='btnVerify' runat="server" Text="Verify" OnClick="btnVerify_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
