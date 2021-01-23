    private List<selectedItem<string>> data;
    public MainViewModel()
    {
        this.data = new List<SelectedItem<string>>
        {
            new SelectedItem<string>("Co. Name");
            new SelectedItem<string>("Rating");
            // Etc.
        }
    }
    public List<SelectedItem<string>> Data
    {
        get { return this.data; }
        set { this.data = value; this.OnPropertyChanged(); }
    }
