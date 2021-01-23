    namespace SimERP
    {
        public partial class Employee : System.Web.UI.Page
        {
            int selectedid = -1;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                   LoadEmployeeData();
                }
            }
