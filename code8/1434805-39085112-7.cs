        private void blaze_125_listbox4_Drop_anotherSpin(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] droppedFilePaths =
                    e.Data.GetData(DataFormats.FileDrop, true) as string[];
                for (int i = 0; i < droppedFilePaths.Length; i++)
                {
                    var filePath = droppedFilePaths[i];
                    var fileName = System.IO.Path.GetFileName(filePath);
                    //fileDictionary.Add(fileName, filePath);
                    listbox4.Items.Add(fileName);
                    listbox4.SelectedItem = fileName;
                }
            }
        }
