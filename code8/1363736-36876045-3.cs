        // Need your model instance.
    private ModelView Model;
    public MainWindow()
        {
            InitializeComponent();
            Model = new ModelView();
            dgNumbers.DataContext = Model;
        }
