    String cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    string cartQuantity;
    // this will be executed when the page is loaded at the beginning or when refreshed
    protected void Page_Load(object sender, EventArgs e)
    {
        // I don't know what this does, if you also need it for the update
        // then put it into the updateQuantity method
        if (!IsPostBack)
        {
            LoadList();
        }
        // update quantity
        updateQuantity();
    }
    // method to update the quantity
    private void updateQuantity()
    {
        if (Session["addtocart"] != null)
        {
            DataTable dt = new DataTable();
            cartQuantity = Convert.ToString(dt.Rows.Count);
        }
        else
        {
            cartQuantity = "0";
        }
        Master.OnlbCartCountMasterPage.Text = cartQuantity;
    }
    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        ListViewItem item = (ListViewItem)btn.NamingContainer;
        HiddenField hfid = item.FindControl("hfId") as HiddenField;
        Label lblitem= item.FindControl("item") as Label;
        Label lblPrice = item.FindControl("lblPrice") as Label;
        DropDownList lblQuantity = item.FindControl("qtydrpdwn") as DropDownList;
        Label lblTotal = item.FindControl("Total") as Label;
        HiddenField hfimg = item.FindControl("imgpath") as HiddenField;
        add2cart(Convert.ToInt32(hfid.Value),lblitem.Text, Convert.ToInt32(lblPrice.Text), Convert.ToInt32(lblTotal.Text), Convert.ToInt32(lblQuantity.Text),hfimg.Value);
        btn.Enabled = false;
        //call update method
        updateQuantity();
    }
