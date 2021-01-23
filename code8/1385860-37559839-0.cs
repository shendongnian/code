    public partial class aaa_useRepeater : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = GetData();
            Repeater1.DataSource = list;
            Repeater1.DataBind();
        }
        private List<Prod> GetData()
        {
            var p1 = new Prod { ID = 0, Name = "Product 1" };
            var p2 = new Prod { ID = 1, Name = "Product 2" };
            var p3 = new Prod { ID = 2, Name = "Product 3" };
            var p4 = new Prod { ID = 3, Name = "Product 4" };
            var list = new List<Prod> { p1, p2, p3, p4 };
            return list;
        }
    }
    public class Prod
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
