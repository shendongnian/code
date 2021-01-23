    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication
    {
        public partial class MCVE: Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    List<int> uselessData = new List<int>(new int[] { 1, 2 });
                    this.rptTest.DataSource = uselessData;
                    this.rptTest.DataBind();
                }
            }
    
            protected void rptTest_ItemCommand(object source, RepeaterCommandEventArgs e)
            {
                HiddenField hiddenField = (HiddenField)e.Item.FindControl("hfSelectedValue");
                this.lblViewResult.Text = hiddenField.Value;
            }
       
        }
    }
