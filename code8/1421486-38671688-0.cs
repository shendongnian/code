    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public partial class ModalPopupFromGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Use txtSearch.Text to lookup the data you want to bind to the GridView, mine is hardcoded for the sake of simplicity
            var p1 = new Person { Name = "Name 1", Surname = "Surname 1" };
            var p2 = new Person { Name = "Name 2", Surname = "Surname 2" };
            GridView1.DataSource = new List<Person> { p1, p2 };
            GridView1.DataBind();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "showPopup();", true);
        }
    }
