    void PB_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(ListViewItem))) 
            e.Effect = DragDropEffects.Move;
        else
            e.Effect = DragDropEffects.None;
    }
    void PB_DragDrop(object sender, DragEventArgs e)
    {
        PictureBox pb = sender as PictureBox;
        var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
        int index = item.ImageIndex;
        pb.Image = imageList1.Images[index];  // make sure you have images for indices!!
           
    }
