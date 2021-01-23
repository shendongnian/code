    protected void MyButtonClick(object sender, System.EventArgs e)
    {
    //Get the button that raised the event
    Button btn = (Button)sender;
    //Get the row that contains this button
    GridViewRow gvr = (GridViewRow)btn.NamingContainer;
    } 
