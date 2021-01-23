    public void renameAndResizeFiles()
    {
        string[] fileEntries = Directory.GetFiles(directory);
        int filesNumber = fileEntries.Length;
        myProgressBar.Maximum = filesNumber;
        int i = 1;
        foreach (string oldFileNamePath in fileEntries) {
            // handle file work
            i++;
            progressBar.Value = i;
        }
        progressBar.Value = 0;
    }
