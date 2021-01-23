    protected void Page_Load(object sender, EventArgs e)
    {
           if (!IsPostBack)
            {
                GridviewBind();
            }
    }
    <asp:UpdatePanel ID="updatepnl" runat="server">
       <ContentTemplate>
            ---GridView---
        </ContentTemplate>
    </asp:UpdatePanel>
