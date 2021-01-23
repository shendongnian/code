    <asp:GridView ID="GridView" runat="server" AllowSorting="True" OnRowDataBound="OnRowDataBound" OnSorting="OnSorting" AutoGenerateColumns="True" OnSelectedIndexChanged="OnSelectedIndexChanged" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnSelect" runat="server" CommandName="Select" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
