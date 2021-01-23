     protected void Page_Load( ...  )
     {
        if (!Page.IsPostBack)
        {
            int roleID = Convert.ToInt32(Session["Role"]);
            if (roleID == 2)
            {
               SetTutor();
            }
            else if (roleID == 0)
            {
               SetAdmin();
            }
            else if (roleID == 9)
            {
                SetStudent();
            }
            lblUsername.Text = Session["Username"].ToString();
            lblEmailAddress.Text = Session["EmailAddress"].ToString();
            getModuleDetails();
        }
       private void SetTutor()
       {
            Label1.Text = "tutor";
            ibtnApproveQuestions.Visible = true;
            ibtnCreateTest.Visible = true;
            lblRole.Visible = true;
            rblRole.Visible = true;
            rblRole.Items.Insert(0, new ListItem("Tutor", "T"));
            rblRole.SelectedValue = "T";
       }
      }
       private void SetAdmin()
       {
                Label1.Text = "admin";
                ibtnApproveQuestions.Visible = true;
                ibtnCreateTest.Visible = true;
                ibtnModifyUsers.Visible = true;
                lblRole.Visible = true;
                rblRole.Visible = true;
                rblRole.Items.Insert(0, new ListItem("Admin", "A"));
                rblRole.SelectedValue = "A";
       }
    
       private void SetStudent()
       {
           Label1.Text = "student view";
                lblRole.Visible = true;
                rblRole.Visible = true;
                rblRole.SelectedValue = "S";
                if (Session["PermanentRole"].ToString().Equals("tutor"))
                {
                    rblRole.Items.Insert(0, new ListItem("Tutor", "T"));
                }
                else if (Session["PermanentRole"].ToString().Equals("admin"))
                {
                    rblRole.Items.Insert(0, new ListItem("Admin", "A"));
                }
       }
