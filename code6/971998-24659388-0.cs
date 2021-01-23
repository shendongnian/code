    <asp:Panel ID="APanel" runat="server" CssClass="CustomerName clearfix">
        <div class="txtInput width464">
            <asp:TextBox ID="txtA" runat="server" MaxLength="12" />
        </div>
    </asp:Panel>
    <asp:Panel ID="BPanel" runat="server" CssClass="CustomerName clearfix">
        <div class="txtInput width464">
            <asp:TextBox ID="txtB" runat="server" MaxLength="20" autocomplete="off"/>
        </div>
    </asp:Panel>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (CurrentOrderItem.MasterModelName.ToLower().Contains("string1"))
            {
                APanel.Visible = true;
                BPanel.Visible = false;
            }
            else
            {
                APanel.Visible = false;
                BPanel.Visible = true;
            }
        }
    }
