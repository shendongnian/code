    <asp:TemplateField>
        <ItemTemplate>
            <asp:Panel ID="lblPD1" runat="server" Text="blah1" 
                BackColor='<%# DateTime.Parse(Eval("[Due Date]").ToString()) < DateTime.Today ? System.Drawing.Color.Red : System.Drawing.Color.Black %>'>
                blah
            </asp:Panel>
        </ItemTemplate>
    </asp:TemplateField>
