     <asp:GridView ID="grvModel"  runat="server" AlternatingRowStyle-BackColor="#eeeeee" BackColor="#aaccff"  AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button id="btnDel" CommandName="Delete" OnClientClick="btnDel_click" runat="server"Text="Delete" />
                    </ItemTemplate>
             </asp:TemplateField>
            <asp:TemplateField >
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="lblWrite" Text='write here' />
                    </ItemTemplate>
             </asp:TemplateField>
        </Columns>
     </asp:GridView>
