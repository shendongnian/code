    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Action<Point> StatusUpdate{ get; set; }
    private void UserControl1_MouseMove(object sender, MouseEventArgs e)
    {
        if (StatusUpdate!= null)
            StatusUpdate(e.Location);
    }
