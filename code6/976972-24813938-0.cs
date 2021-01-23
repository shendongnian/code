    public void pb_Click(object sender, EventArgs e)
    {
        PictureBox pb = (PictureBox)sender;
        if (pb.Image == Red) { pb.Image = Orange; status.Tag = "Orange"; }
        else if (pb.Image == Orange) { pb.Image = green; status.Tag = "Green"; }
        else if (pb.Image == green) { pb.Image = Red; status.Tag = "Red"; }
    }
