    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var myDropdown = Master.FindControl("myDropdown") as DropDownList;
            for (int i = 0; i < 10; i++)
            {
                myDropdown.Items.Add(i.ToString());
            }
        }
    }
