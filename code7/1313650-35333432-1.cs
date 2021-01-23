    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class UserInfoBoxControl : System.Web.UI.UserControl
    {
    
        private string userName;
        private string fname;
        private string lname;
    
    
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string FirstName
        {
            get { return fname; }
            set { fname = value; }
        }
        public string LastName
        {
            get { return lname; }
            set { lname = value; }
        }
    
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void btnEdit_click(object sender, EventArgs e)
        {
            Session["UserNameMod"] = userName;
            
            Response.Redirect("userinfo.aspx");
        }
    }
