    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register
        (
             "ViewModel", 
             typeof(ExampleViewModel), 
             typeof(ExampleView), 
             new PropertyMetadata(null)
        );
        public ExampleViewModel ViewModel
        {
            get { return (ExampleViewModel)GetValue(ViewModelProperty ); }
            set { SetValue(ViewModelProperty , value); }
        }
        public ExampleView()
        {
            InitializeComponent();
        }
        //..........
