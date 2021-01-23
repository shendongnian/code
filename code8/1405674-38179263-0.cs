    public partial class DisplayGridViewRowInPopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetData();
            }
        }
        public void GetData()
        {
            var p1 = new Product { TransactionID = 1, ItemType = "Type1", ItemModel = "Model1", ItemQuantity = 1, ItemUnit = "Unit1", ItemDate = DateTime.Now, ItemDesc = "Product 1" };
            var p2 = new Product { TransactionID = 2, ItemType = "Type2", ItemModel = "Model2", ItemQuantity = 2, ItemUnit = "Unit2", ItemDate = DateTime.Now, ItemDesc = "Product 2" };
            GridView1.DataSource = new List<Product> { p1, p2 };
            GridView1.DataBind();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int i = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvrow = GridView1.Rows[i];
            txtID.Text = gvrow.Cells[1].Text;
            txtType.Text = gvrow.Cells[2].Text;
            txtModel.Text = gvrow.Cells[3].Text;
            txtQuan.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
            txtUnit.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
            txtDate.Text = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
            txtDesc.Text = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);
            lblResult.Visible = false;
            string script = "<script type='text/javascript'>$('#editModal').modal('show');</script>";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", script, false);
        }
    }
    public class Product
    {
        public int TransactionID { get; set; }
        public string ItemType { get; set; }
        public string ItemModel { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemUnit { get; set; }
        public DateTime ItemDate { get; set; }
        public string ItemDesc { get; set; }
    }
