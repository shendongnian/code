    private void listbox2_Drop(object sender, DragEventArgs e)
    {
    try
    {
        string[] a = (string[])(e.Data.GetData(DataFormats.FileDrop, false));
        foreach (var names in a)
        {
            FileInfo fileInfo = new FileInfo(names);
            if (fileInfo.Extension == ".MP3" ||fileInfo.Extension == ".mp3")
            {
                listbox2.Items.Add(fileInfo); //store the full FileInfo in your Items, not just the Name property
            }
        }
    }
    catch (Exception)
    {}
    }
    
    private void listbox2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {      
        FileInfo listboxItem = listbox2.SelectedItem as FileInfo; //cast the SelectedItem to the FileInfo type
        if (listboxItem != null)
        {
            media2.Open(new Uri(listboxItem.FullPath, UriKind.RelativeOrAbsolute)); // if I remember well, Source is Read-Only, use Open instead
            media2.Play();
        }
    }
