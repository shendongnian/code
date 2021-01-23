    private void OnDrop(object sender, DragEventArgs e)
    {
        var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
        using(var bm = new Bitmap(paths[0]))
        {
            var newPath = paths[0].Substring(paths[0].LastIndexOf("\\") + 1);
            bm.Save(newPath);
        }
        // using block is all done, handle should be released. delete that bad boy.
        File.Delete(paths[0]); 
        pictureEdit1.Image = new Bitmap(newPath);
    }
