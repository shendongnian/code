    List<PictureBox> clickedBoxes = new List<PictureBox>();
    private void pictureBox_Click(object sender, EventArgs e)
    {
       PictureBox pb  = sender as PictureBox;
       if (!clickedBoxes.Contains(pb) ) clickedBoxes.Add(pb);
    }
