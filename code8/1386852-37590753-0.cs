    public partial class GridTwo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<OrderLineItem> lineItems = new List<OrderLineItem>();
            lineItems.Add(new OrderLineItem { Price = 10.00M, Quantity = 0, ItemTotal = 0.00M });
            lineItems.Add(new OrderLineItem { Price = 100.00M, Quantity = 0, ItemTotal = 0.00M });
            lineItems.Add(new OrderLineItem { Price = 5.00M, Quantity = 0, ItemTotal = 0.00M });
            GridView1.DataSource = lineItems;
            GridView1.DataBind();
        }
    }
    public class OrderLineItem
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal ItemTotal { get; set; }
    }
