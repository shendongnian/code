    public partial class formtarget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String name = Request.Form["namebox"];
            String age = Request.Form["agebox"];
            namelab.Text = name;
            agelab.Text = age;
        }
    }
