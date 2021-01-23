    <asp:DataGrid ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="false">
               <Columns>
               <asp:TemplateColumn>
                   <ItemTemplate>
                   <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                       </ItemTemplate>
               </asp:TemplateColumn>
    <asp:BoundColumn DataField="Id" HeaderText="Id"> <!--New Column Added-->
               <asp:BoundColumn DataField="dato" HeaderText="Dato">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="Antal" HeaderText="Antal">
                </asp:BoundColumn>
               <asp:Boundcolumn HeaderText="Navn" Datafield="VareNAvn">
                </asp:Boundcolumn>
           <asp:BoundColumn DataField="KøbtAfBrugerID" HeaderText="Købt af ID">
                </asp:BoundColumn>
                <asp:Boundcolumn HeaderText="Hented" DataField="Afhented">
                    </asp:Boundcolumn>
           </Columns>
        </asp:DataGrid>
      <asp:Button ID="Button_Hented" CssClass="btfarve" runat="server" Text="Afhentet" OnClick="Button_Hented_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString1 %>" 
        SelectCommand="SELECT * FROM [Transactioner] WHERE afhented ='Nej';">
        </asp:SqlDataSource>
