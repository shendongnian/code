    <asp:Button runat="server" id="AddToCartBtn" Text="Put in cart" OnClick="AddToCartBtn_Click" />
    protected void Page_Load()
    {
        AddToCartBtn.CommandArgument=PRODUCT_ID; //assuming you load this from database
    }
    
    protected void AddToCartBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("startpage.aspx?ID={0}", AddToCartBtn.CommandArgument));
    }
