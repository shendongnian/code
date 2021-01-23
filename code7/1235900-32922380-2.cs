    void PB_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.Text))
            e.Effect = DragDropEffects.Move;
        else
            e.Effect = DragDropEffects.None;
    }
    void PB_DragDrop(object sender, DragEventArgs e)
    {
        PictureBox pb = sender as PictureBox;
        string t = (string)e.Data.GetData(DataFormats.Text);
        int index = Convert.ToInt16(t);
        pb.Image = imageList1.Images[index];
           
    }
