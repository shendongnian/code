    private void commonPBox_MouseDown(object sender, MouseEventArgs e)
    {
        PictureBox PB = sender as PictureBox;
        if (PB == null) return; //or throw an exception
        PB.DoDragDrop(PB .Image, DragDropEffects.Copy);
    }
    private void commonPanel_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }
    private void commonPanel_DragDrop(object sender, DragEventArgs e)
    {
        Panel Pan = sender as Panel;
        if (Pan == null) return; //or throw an exception
        //Set background image of panel to selected avatar
        Pan.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
    }
