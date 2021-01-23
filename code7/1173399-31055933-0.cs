    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            TeamsByRole myUserControl = (TeamsByRole)LoadControl("TeamsByRole.ascx");
            myUserControl.UserID = i;
            PlaceHolder1.Controls.Add(myUserControl);
        }
    }
