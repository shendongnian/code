    public partial class YourPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        // This will get called when your form is submitted
        protected void AddPassword_Click(object sender, EventArgs e)
        {
            // When your page is posted back, compare your passwords
            if(String.Equals(Password1.Text,Password2.Text))
            {
                // Your passwords are equal, do something here
            }
            else
            {
                // They aren't equal, do something else
            }
        }
    }
