    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text="0"></asp:Label>
                            &nbsp;
                            <asp:LinkButton ID="lbtnPlus" runat="server" Text="+" OnClick="lbtnPlus_Click"></asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton ID="lbtnMinus" runat="server" Text="-" OnClick="lbtnMinus_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gv" />
        </Triggers>
    </asp:UpdatePanel>
