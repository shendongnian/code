        private void blaze_125_listbox4_Drop_Slimmer(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] droppedFilePaths =
                    e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (string droppedFilePath in droppedFilePaths)
                {
                    listbox4.Items.Add(System.IO.Path.GetFileName(droppedFilePath));
                }
            }
        }
