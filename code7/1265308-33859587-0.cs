    // the assignment below is not needed since you are assigning it again on the very next line
    //HtmlGenericControl liItem1 = new HtmlGenericControl();
    HtmlGenericControl liItem1 = (HtmlGenericControl)this.Master.FindControl("logtop_bar");
    // this line below will print which master page you are using
    Response.Write(this.Master.MasterPageFile);
    // only set the attribute if it is not null.
    if (liItem1 != null) {
        liItem1.Attributes.Add("style", "display:block");
    }
