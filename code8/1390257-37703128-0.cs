    public partial class aGridViewDetailsHover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                GridView1.DataSource = this.GetUsers();
                GridView1.DataBind();
            }
        }
        private List<MyUser> GetUsers()
        {
            var u1 = new MyUser { Name = "User1 Name", Surname = "User1 Surname", HiddenComment = "Hidden Comment For User 1" };
            var u2 = new MyUser { Name = "User2 Name", Surname = "User2 Surname", HiddenComment = "Hidden Comment For User 2" };
            var u3 = new MyUser { Name = "User3 Name", Surname = "User3 Surname", HiddenComment = "Hidden Comment For User 3" };
            return new List<MyUser> { u1, u2, u3 };
        }
    }
    public class MyUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HiddenComment { get; set; }
    }
