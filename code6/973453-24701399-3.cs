    <asp:Button runat="server" id="AddToCartBtn" Text="Put in cart" OnClick="AddToCartBtn_Click" />
    protected void Page_Load()
    {
        //assuming you load product from database, possibly using Entity Framework
        AddToCartBtn.CommandArgument = product.ProductId;
    }
    
    protected void AddToCartBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("startpage.aspx?ID={0}", AddToCartBtn.CommandArgument));
    }
