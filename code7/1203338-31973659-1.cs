    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Telerik.Web.UI;
    
    namespace TelerikWebApp1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object source, System.EventArgs e)
            {
    
            }
    
            protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
            {
                dynamic data = new[] {
            new { ID = 1, Name ="Name1"},
            new { ID = 2, Name ="Name2"} };
                RadGrid1.DataSource = data;
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                Button Button1 = sender as Button;
                GridDataItem item = Button1.NamingContainer as GridDataItem;
                string strID = item["ID"].Text;
                (usercontrol1.FindControl("Label1") as Label).Text = strID;
                RadWindow1.VisibleOnPageLoad = true;
            }
    
    
        }
    }
