    <asp:DataList runat="server" ID="test" OnItemCommand="test_ItemCommand">
        <ItemTemplate>
            <asp:Label runat="server" ID="Label2" Text="Test" />
        </ItemTemplate>
    </asp:DataList>
---
    protected void test_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        if (e.Item != null)
        {
            var label2 = e.Item.FindControl("Label2");
            if (label2 != null && label2 is Label)
            {
                var productID = ((Label)label2).Text;
                // now you have the contents of the label's text property
            }
        }
    }
