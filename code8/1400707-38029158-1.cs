      public partial class GridViewRowCommandExample : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if(!Page.IsPostBack)
                {
                    var p1 = new Product { CustomerID = 1, ProductID = 11 };
                    var p2 = new Product { CustomerID = 2, ProductID = 22 };
    
                    GridView1.DataSource = new List<Product> { p1, p2 };
                    GridView1.DataBind();
                }
            }
    
            protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "UpdateProduct")
                {
                    string[] parameters = e.CommandArgument.ToString().Split(',');
                    int customerID = Int32.Parse(parameters[0]);
                    int productID = Int32.Parse(parameters[1]);
                    //Now that you know which row to update run the SQL update statement 
                }
            }
        }
    
        public class Product
        {
            public int CustomerID { get; set; }
            public int ProductID { get; set; }
        }
