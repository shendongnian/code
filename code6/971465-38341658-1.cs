    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<TransferBO> List2 = new List<TransferBO>();
                TransferDAL obj1 = new TransferDAL();
                List2 = obj1.view();
                Gridview1.DataSource = List2;
                Gridview1.DataBind();
            }
        }
        protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow SelectedRow = Gridview1.SelectedRow;
            Label id1 = (Label)SelectedRow.FindControl("Label1") as Label;
            int id2 = Convert.ToInt32(id1.Text);
            Label id3 = (Label)SelectedRow.FindControl("Label3") as Label;
            string id4 = Convert.ToString(id3.Text);
            Session["id"] = id2;
            Session["name"] = id4;
            Response.Redirect("Approve.aspx");
        }
    }
