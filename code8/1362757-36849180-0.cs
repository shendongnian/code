    namespace EUCNET01316
    {
        public partial class Survey : System.Web.UI.UserControl
        {
    
             protected void Page_Load(object sender, EventArgs e)
             {
                 SqlDataSource1.SelectParameters["Category"].DefaultValue = ?????;
                 GridView1.DataSourceID = "SqlDataSource1";
                 GridView1.DataBind();  
             }
             public string MyParameterValue {get;set;}
         }
     }
