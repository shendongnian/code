    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //session set
            Session["message"] = "Hello World";
            //session get
            lblMessage.Text = Session["message"].ToString();
    
            //viewstate set
            ViewState["message"] = "Hi there world";
            //viewstate get
            lblMessageView.Text = ViewState["message"].ToString();
    
    
        }
    
        protected void SubmitForm_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ViewState["New"] = TextView1.Text;         //makes new viewstate with text result
                TextView2.Text = ViewState["New"].ToString(); //Trying to enter viewstate data in text box
            }
            
        }
    
        protected void SubmitForm_Click2(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Session["New"] = SessionTextBox.Text; //makes new session with text result
                SessionResultTextBox.Text = Session["New"].ToString();  //Trying to enter session data into text box
            }
            
        }
    
    
    
    }
