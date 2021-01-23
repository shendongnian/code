    namespace WebApplication1
    {
        public partial class Singnup : System.Web.UI.Page
        {
            protected void SUpButton_Click(object sender, EventArgs e)
            {
                string EmailId = "yourmailid@domain.com";
                Webapplication2.program.InsertRData(EmailId);
            }
        }
    }
    
    namespace Webapplication2
    {
        public class program : WebApplication1.Singnup
        {
            public static void Insert_RData(object sender, EventArgs e)
            {
                string EmailId = "yourmailid@domain.com";
                InsertRData(EmailId);
            }
    
            public static void InsertRData(string EmailId)
            {
                SqlConnection con_Signup = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
                con_Signup.Open();
                SqlCommand cmd_check = new SqlCommand("Check_Existing_Email", con_Signup);
                cmd_check.CommandType = CommandType.StoredProcedure;
                cmd_check.Parameters.AddWithValue("@mail", EmailId);
                object i = cmd_check.ExecuteScalar();
    
                if (i != null)
                {
                    lbforerror.Text = "This Email is already Registered";
                    lbforerror.Visible = true;
                }
            }
        }
    }
