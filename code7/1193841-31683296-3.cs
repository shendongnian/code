    public string FilePath
    {
        get
        {
            return _filePath;
        }
        set
        {
            _filePath = value;
            RaisePropertyChanged("FilePath");
        }
    }
    
    public ICommand BrowseFileCommand = new DelegateCommand(BrowseFile);
    
    public void BrowseFile()
    {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
    
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF Files (*.pdf)|*.pdf";
    
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();
    
            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // set chosenFile variable
                this.FilePath = dlg.FileName;
            }
    }
