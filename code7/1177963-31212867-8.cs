    private void dropPanel_DragEnter(object sender, DragEventArgs e)
    {
            
        if (e.Data.GetDataPresent(DataFormats.Text))
                { e.Effect = DragDropEffects.Copy;            }
        else  { e.Effect = DragDropEffects.None; }
    }
    private void dropPanel_DragDrop(object sender, DragEventArgs e)
    {
        dragFrame.Hide();
        timer1.Stop();
    }
