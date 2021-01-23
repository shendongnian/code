    public partial class DataListExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            MyStock stock1 = new MyStock { Product_Id = 1, Stock = "Stock 1" };
            MyStock stock2 = new MyStock { Product_Id = 2, Stock = "Stock 2" };
            dListProduct.DataSource = new List<MyStock> { stock1, stock2 };
            dListProduct.DataBind();
        }
        protected void dListProduct_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Label lbl = (Label)e.Item.FindControl("lblPId");
            Response.Write(lbl.Text);
        }
    }
    public class MyStock
    {
        public int Product_Id { get; set; }
        public string Stock { get; set; }
    }
