     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptrItems.DataSource = new List<Item>
                {
                    new Item {ItemName = "Item Name",Quantity=1}
                };
                rptrItems.DataBind();
            }
        }
    
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataListItem item in rptrItems.Items)
            {
                string quantity = ((TextBox)item.FindControl("txtQuantity")).Text;
                string itemName = ((HiddenField)item.FindControl("itemName")).Value;
            }
        }
     
        public class Item
        {
            public string ItemName { get; set; }
    
            public int Quantity { get; set; }
        }
     <asp:DataList runat="server" ID="rptrItems">
    <ItemTemplate>
    	<asp:HiddenField ID="itemName" runat="server" Value='<%# Eval("ItemName") %>' />
    	<asp:Label ID="labItemName" runat="server" Text='<%# Eval("ItemName") %>' /> : 
    	<asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
    </ItemTemplate>
    </asp:DataList>
    <asp:Button ID="btnSubmit" OnClick="btnAdd_Click" runat="server" Text="Submit" />
