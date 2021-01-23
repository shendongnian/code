    public partial class API_Menu_Ping : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void PingCaApi_Click(object sender, EventArgs e)
        {
            PingResult.Text = null;
    
            //Create credentials
            var cred = new ca.api.APICredentials();
            cred.DeveloperKey = ConfigurationManager.AppSettings["CADeveloperKey"];
            cred.Password = ConfigurationManager.AppSettings["CAPassword"];
    
            //Create the Web Service and attach the credentials
            var svc = new ca.api.AdminService();
            svc.APICredentialsValue = cred;
    
            //call the method
            var result = svc.Ping();
    
           PingResult.Text = (result.ResultData == "ok") ? "your ping was successful" : "your ping failed";
        }
    }
