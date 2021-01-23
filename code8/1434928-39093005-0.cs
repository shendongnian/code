    private void load_Click(object sender, RoutedEventArgs e)
    {
    	var listCount = listbox4.Count;
        Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
        ofd.DefaultExt = ".mp3";
        ofd.Filter = "All|*.*";
        ofd.Multiselect = true;
        Nullable<bool> result = ofd.ShowDialog();
        if (result == true)
        {		
            for (int i = 0; i < ofd.FileNames.Length; i++)
            {
                var filePath = ofd.FileNames[i];
                var fileName = System.IO.Path.GetFileName(filePath);
                fileDictionary.Add(fileName, filePath);
                listbox4.Items.Add(fileName);
            }
    		listbox4.SelectedIndex = listCount;
        }
    }
    private void listbox4_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
			var listCount = listbox4.Count;
            string[] droppedFilePaths =
                e.Data.GetData(DataFormats.FileDrop, true) as string[];
            foreach (string droppedFilePath in droppedFilePaths)
            {
                var filePath = droppedFilePath;
                var fileName = System.IO.Path.GetFileName(filePath);
                fileDictionary.Add(fileName, filePath);
                listbox4.Items.Add(fileName);
            }
			if(droppedFilePaths.Any())
			{
				listbox4.SelectedIndex = listCount;
			}
        }
    }
