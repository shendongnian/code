    <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:BoundField DataField="NumberFormat.CurrencySymbol" />
            </Columns>
     </asp:GridView>
       
    var cls = System.Globalization.CultureInfo.GetCultures(Globalization.CultureTypes.AllCultures);
    GridView1.DataSource = cls;
    GridView1.DataBind();
