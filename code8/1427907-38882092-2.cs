    if (Request.IsAuthenticated)
    {
        MyControl1 control = (MyControl1)LoadControl("~/MyControl1.ascx");
        Panel1.Controls.Add(control);
    }
    else
    {
        MyControl2 control = (MyControl2)LoadControl("~/MyControl2.ascx");
        Panel1.Controls.Add(control);
     }
