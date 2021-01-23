    public partial class test: System.Web.UI.Page
    {
       private String msg;
       protected void Page_Load(object sender, EventArgs e)
       {
           status.Text = Session["message"].ToString();
       }
       protected void action(object sender, EventArgs e)
       {
           msg = "Hello world!";
           Session["message"] = msg;
       }
    }
