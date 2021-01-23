    <asp:LinkButton ID="LinkButton1" runat="server" Text="">
            <asp:Image ID="Image1" ImageUrl="" runat="server" />
    </asp:LinkButton>
    
    
    if(!Page.IsPostBack)
    {
       LinkButton1.OnClientClick = "ClientClick()";
       Image1.ImageUrl = "~/Images/embed.png";
    }
