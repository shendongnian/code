    private void panel_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
    
        if (e.Data.GetDataPresent(typeof(Button).FullName)) // button
            e.Effect = DragDropEffects.Copy;
        else
            e.Effect = DragDropEffects.None;
    }
