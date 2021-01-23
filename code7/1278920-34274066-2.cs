    void pictureBox_MouseWheel(object sender, MouseEventArgs e)
    {
        //Some parameter that you extract from eventArgs or somewhere else
        int zoomFactor = e.Delta;
        //Call the method on your picture boxes
        foreach (var p in pictureBoxes)
        {
            Zoom(p, zoomFactor);
        }
    }
  
    //The method that contains logic of zoom on a picture box
    public void Zoom(PictureBox p, int zoomFactor)
    {
        //It is just an example, not a real logic
        p.SizeMode = PictureBoxSizeMode.Zoom;
        p.Width += (zoomFactor * 10);
        p.Height += (zoomFactor * 10);
    }
