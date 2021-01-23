    public partial class Singnup : System.Web.UI.Page
    {
        protected void SUpButton_Click(object sender, EventArgs e)
        {
            ConnectionManager mgr = new ConnectionManager();
            object i = mgr.Insert_RData("email logic here");
            if (i != null)
            {
                lbforerror.Text = "This Email is already Registered";
                lbforerror.Visible = true;
            }
        }
    }
