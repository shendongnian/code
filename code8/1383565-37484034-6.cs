    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Action<Point> StatusUpdate{ get; set; }
    //Don't forget to assign the method to MouseMove event in your user control 
    private void UserControl1_MouseMove(object sender, MouseEventArgs e)
    {
        if (StatusUpdate!= null)
            StatusUpdate(e.Location);
    }
