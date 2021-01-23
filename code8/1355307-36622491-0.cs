    private void Rtb_DragDrop(object sender, DragEventArgs e)
    {
        StringCollection sFiles = new StringCollection();
        if (e.Data.GetDataPresent("FileDrop"))
        {
            foreach (string file in (string[])e.Data.GetData("FileDrop"))
            {
                Clipboard.Clear();
                sFiles.Clear();
                sFiles.Add(file);
                Clipboard.SetFileDropList(sFiles);
                rtb.Paste();  //it's not necessary to specify the format
            }
        }
    }
