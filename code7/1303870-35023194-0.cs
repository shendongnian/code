    public Card()
    {
        InitializeComponent();
        this.DataContext = this; // Bad!
    }
    public Card(string title, string description)
    {
        InitializeComponent();
        this.DataContext = this; // Bad!
        this.Title.Text = title; // Should be replaced with bindings as above
        this.Description.Text = description; // Should be replaced with bindings as above
    }
