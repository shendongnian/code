    public IEnumerable<FileData> FilteredFiles
    {
        get
        {
            if (Unique)
            {
                return Files.GroupBy(item => item.TID).Select(grp => grp.First());
            }
            else
            {
                return Files.GroupBy(item => item.CID).Select(grp => grp.First());
            }
        }
    }
    
    public ObservableCollection<FileData> Files
    {
        get; set;
    }
    
    public bool Unique
    {
        get
        {
            return unique;
        }
        set
        {
            unique = value;
            RaisePropertyChanged("FilteredFiles");
        }
    }
