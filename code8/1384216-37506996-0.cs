    protected void Page_Load(object sender, EventArgs e)
    {
        RoomsUserControl r1 = (RoomsUserControl)Page.LoadControl("~/RoomsUserControl.ascx");
        r1.ID = "Room1";
        pl1.Controls.Add(r1);
        RoomsUserControl r2 = (RoomsUserControl)Page.LoadControl("~/RoomsUserControl.ascx");
        r2.ID = "Room2";
        pl1.Controls.Add(r2);
        RoomsUserControl r3 = (RoomsUserControl)Page.LoadControl("~/RoomsUserControl.ascx");
        r3.ID = "Room3";
        pl1.Controls.Add(r3);
    }
