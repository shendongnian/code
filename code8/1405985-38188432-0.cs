    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "h")
        {
            Button btn = (Button)(e.CommandSource);
            if(btn.Text == "hide")
            {
               btn.Text = "unhide";
               //Do additional work here, when unhiding.
            }
            else
            {
               btn.Text = "hide";
               //Do additional work here, when hiding.
            }
        }
    }
