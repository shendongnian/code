    private void DoStuffAndClosePanel(object sender, EventArgs e)
    {
    
        //Do Stuff
        //...
        //Close Panel
        var parent=((Control)sender).Parent;
        parent.Visible = false;
        parent.Dispose();
        parent = null;
    }
           
