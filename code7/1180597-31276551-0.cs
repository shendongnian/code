    private void Form_Shown(object sender, EventArgs e)
    {
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        GetAllPictureBoxes(ref pictureBoxes, this.Controls);
        PictureBox[] pictureBoxesArray = pictureBoxes.OrderBy(pb => pb.Name).ToArray();
    }
    private void GetAllPictureBoxes(ref List<PictureBox> pictureBoxes, Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control.HasChildren)
                GetAllPictureBoxes(ref pictureBoxes, control.Controls);
            if (control is PictureBox)
                pictureBoxes.Add((PictureBox)control);
        }
    }
