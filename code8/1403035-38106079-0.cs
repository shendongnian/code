    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public partial class GridViewValidation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            var u1 = new User { ID = 1, Name = "User1" };
            var u2 = new User { ID = 2, Name = "User2" };
            GridView1.DataSource = new List<User> { u1, u2 };
            GridView1.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList doublePartner = (row.Cells[2].FindControl("ddlDoublePartner") as DropDownList);
                    doublePartner.BackColor = doublePartner.SelectedValue.Equals("-1") ? Color.Red : Color.Transparent;
                }
            }
        }
    }
