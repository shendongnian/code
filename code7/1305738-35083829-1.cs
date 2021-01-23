    public ObservableCollection<ComboBoxData> Languages { get; set; }
    public View()
        {
            InitializeComponent();
    
            this.Languages = new ObservableCollection<ComboBoxData>()
                              {
                                  new MyComboboxData(){Path = "Image1.jpg", Text = "Text1"},
                                  new MyComboboxData(){Path = "Image2.jpg", Text = "Text2"}
                              };
    
            this.DataContext = this;
    }
