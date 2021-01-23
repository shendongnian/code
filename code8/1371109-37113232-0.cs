    protected void Page_Load(object sender, EventArgs e)
            {
               if (Page.IsPostBack == false)
               { 
                  buttonVisibility();
                 }
            }
    
    private void buttonVisibility()
        {
            if (lblUserType.Text == "special_user")
            {
                txtDisc.Visible = true;
                lblLock.Visible = false;
            }
        }
