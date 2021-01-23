    private void panel1_MouseClick(object sender, MouseEventArgs e)
    {
        foreach(Line L in lines) 
                L.LineColor = L.HitTest(e.Location) ?  Color.Red : Color.Black;
        panel1.Invalidate();
    }
