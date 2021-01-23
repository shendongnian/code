    <asp:Repeater ID="rptTest" runat="server">
                <ItemTemplate>
                    Request.URL = <%# Eval("Url") %>
                </ItemTemplate>
    </asp:Repeater>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var objTest = Request; //Using the Request object as a test business object
            rptTest.DataSource = new List<System.Web.HttpRequest>() { objTest };
            rptTest.DataBind();
        }
    }
